using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Persistence;
using Syncfusion.EJ.Export;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.Models;
using Syncfusion.XlsIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;

namespace EasyLOB
{
    public partial class SyncfusionGrid
    {
        #region Properties

        Type Type { get; }

        public string DataNamespace { get; }

        public bool HasServerSideJoins { get; }

        #endregion Properties

        #region Methods

        public SyncfusionGrid(Type type, ZDBMS dbms)
        {
            Type = type;
            DataNamespace = type.Namespace;
            HasServerSideJoins = PersistenceHelper.HasServerSideJoins(dbms);
        }

        #endregion Methods

        #region Methods Export (static)

        // DataManager                      =>  GridProperties

        // SearchFilter
        // dataManager.Search[0].Fields     =>
        // dataManager.Search[0].Key        =>
        // dataManager.Search[0].Operator   =>

        // WhereFilter                          FilteredColumn
        // dataManager.Where[0].Field       =>  gridProperties.FilterSettings.FilteredColumns[0].Field
        // dataManager.Where[0].Operator    =>  gridProperties.FilterSettings.FilteredColumns[0].Operator
        // dataManager.Where[0].predicates  =>  gridProperties.FilterSettings.FilteredColumns[0].Predicate
        // dataManager.Where[0].value       =>  gridProperties.FilterSettings.FilteredColumns[0].Value

        // Sort                                 SortedColumn
        // dataManager.Sorted[0].Name       =>  gridProperties.SortSettings.SortedColumns[0].Field
        // dataManager.Sorted[0].Direction  =>  gridProperties.SortSettings.SortedColumns[0].Direction

        public static void ExportToExcel(string gridModel, IEnumerable data, string fileName, string theme)
        {
            GridProperties gridProperties = ModelToObject(gridModel);

            ExcelExport export = new ExcelExport();
            export.Export(gridProperties, data, fileName, ExcelVersion.Excel2013, false, false, theme);
        }

        public static void ExportToPdf(string gridModel, IEnumerable data, string fileName, string theme)
        {
            GridProperties gridProperties = ModelToObject(gridModel);

            PdfExport export = new PdfExport();
            export.Export(gridProperties, data, fileName, false, false, true, theme); // UNICODE = true
            //export.Export(gridProperties, data, fileName, false, false, theme);
        }

        public static void ExportToWord(string gridModel, IEnumerable data, string fileName, string theme)
        {
            GridProperties gridProperties = ModelToObject(gridModel);

            WordExport export = new WordExport();
            export.Export(gridProperties, data, fileName, false, false, theme);
        }

        public static GridProperties ModelToObject(string gridModel)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IEnumerable data = (IEnumerable)serializer.Deserialize(gridModel, typeof(IEnumerable));
            GridProperties gridProperties = new GridProperties();
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase;
            foreach (KeyValuePair<string, object> keyValue in data)
            {
                var property = gridProperties.GetType().GetProperty(keyValue.Key, bindingFlags);
                if (property != null)
                {
                    System.Type type = property.PropertyType;
                    string serialize = serializer.Serialize(keyValue.Value);
                    object value = serializer.Deserialize(serialize, type);
                    property.SetValue(gridProperties, value, null);
                }
            }

            return gridProperties;
        }

        #endregion Methods Export (static)

        #region Methods Sycnfusion.Javascript.DataManager - Grid

        public string ToLinqWhere(List<SearchFilter> searchFilters, List<WhereFilter> whereFilters, ArrayList arguments)
        {
            int argument = 0;
            string result;

            string search = SearchToLinq(searchFilters, arguments, ref argument);
            string where = WhereToLinq(whereFilters, arguments, ref argument);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(where))
            {
                result = search + " && " + where;
            }
            else
            {
                result = search + where;
            }

            return result;
        }

        public string ToLinqOrderBy(List<Sort> sorts)
        {
            return SortToLinq(sorts);
        }

        #endregion Methods Sycnfusion.Javascript.DataManager - Grid

        #region Methods Sycnfusion.Javascript.DataManager - Search

        private string SearchToLinq(List<SearchFilter> searchFilters, ArrayList arguments, ref int argument)
        {
            string where = "";

            if (searchFilters != null)
            {
                string condition = " || ";
                foreach (SearchFilter searchFilter in searchFilters)
                {
                    foreach (string field in searchFilter.Fields)
                    {
                        if (field.Contains(","))
                        {

                            // searchFilters[0].Fields = "[\"CategoryId\",\"CategoryName\"]"

                            string[] searchFields = field.Replace("[", "").Replace("]", "").Split(',');
                            foreach (string searchField in searchFields)
                            {
                                string linq = SearchExpressionToLinq(searchFilter.Operator,
                                    searchField.Replace("\"", ""),
                                    searchFilter.Key, arguments, ref argument);
                                if (linq != "")
                                {
                                    where = where != "" ? where + condition : where;
                                    where += linq;
                                }
                            }
                        }
                        else
                        {

                            // searchFilters[0].Fields = "[\"CategoryId\"]"

                            string linq = SearchExpressionToLinq(searchFilter.Operator,
                                field.Replace("[", "").Replace("]", "").Replace("\"", ""),
                                searchFilter.Key, arguments, ref argument);
                            if (linq != "")
                            {
                                where = !string.IsNullOrEmpty(where) ? where + condition : where;
                                where += linq;
                            }
                        }
                    }
                }

                if (where != "")
                {
                    where = "(" + where + ")";
                }
            }

            return where;
        }

        private string SearchExpressionToLinq(string whereOperator, string field, string key,
            ArrayList arguments, ref int argument)
        {
            string linq = "";

            field = LookupTextToWhere(field);
            if (field != "")
            {
                // LINQ to Entities does not recognize the method 'System.String ToString()' method, and this method cannot be translated into a store expression
                //linq = field + ".ToString().Contains(@" + argument++.ToString() + ")";
                Type type = LibraryHelper.GetType(Type, field);
                if (type != null)
                {
                    if (LibraryHelper.IsBoolean(type))
                    {
                        //bool value = key.ToBoolean();
                        //arguments.Add(value);
                        //linq = field + " == @" + argument++.ToString();
                    }
                    else if (LibraryHelper.IsDateTime(type))
                    {
                        DateTime value = key.ToDateTime();
                        if (value != default(DateTime))
                        {
                            arguments.Add(value);
                            linq = field + " == @" + argument++.ToString();
                        }
                    }
                    else if (LibraryHelper.IsFloat(type))
                    {
                        double value = key.ToDouble();
                        if (value != default(double))
                        {
                            arguments.Add(value);
                            linq = field + " == @" + argument++.ToString();
                        }
                    }
                    else if (LibraryHelper.IsInteger(type))
                    {
                        int value = key.ToInt32();
                        if (value != default(int))
                        {
                            arguments.Add(value);
                            linq = field + " == @" + argument++.ToString();
                        }
                    }
                    else // if (LibraryHelper.IsString(type))
                    {
                        arguments.Add(key);
                        linq = field + ".Contains(@" + argument++.ToString() + ")";
                    }
                }
                else
                {
                    arguments.Add(key);
                    linq = field + ".Contains(@" + argument++.ToString() + ")";
                }
            }

            return linq;
        }

        #endregion Methods Sycnfusion.Javascript.DataManager - Search

        #region Methods Sycnfusion.Javascript.DataManager - Where

        private string WhereToLinq(List<WhereFilter> whereFilters, ArrayList arguments, ref int argument)
        {
            string where = "";

            if (whereFilters != null)
            {
                where = WhereFilterToLinq(whereFilters[0], arguments, ref argument);
            }

            return where;
        }

        private string WhereFilterToLinq(WhereFilter whereFilter, ArrayList arguments, ref int argument)
        {
            string where = "";

            if (!string.IsNullOrEmpty(whereFilter.Condition))
            {
                string condition = whereFilter.Condition == "and" ? " && " : " || ";

                foreach (WhereFilter predicate in whereFilter.predicates)
                {
                    string linq = WhereFilterToLinq(predicate, arguments, ref argument);
                    if (linq != "")
                    {
                        where = where != "" ? where + condition : where;
                        where += linq;
                    }
                }

                if (where != "")
                {
                    where = "(" + where + ")";
                }
            }
            else // == null | != null
            //else if (whereFilter.value != null)
            {
                where += WhereExpressionToLinq(whereFilter.Operator, whereFilter.Field, whereFilter.value, arguments, ref argument);
            }

            return where;
        }

        private string WhereExpressionToLinq(string whereOperator, string field, object value,
            ArrayList arguments, ref int argument)
        {
            string linq = "";

            field = LookupTextToWhere(field);
            if (field != "")
            {
                if (value != null)
                {
                    // ej.FilterOperators
                    switch (whereOperator.ToLower())
                    {
                        case "contains": // String
                            arguments.Add(value);
                            linq = field + ".Contains(@" + argument++.ToString() + ")";
                            break;

                        case "endswith": // String
                            arguments.Add(value);
                            linq = field + ".EndsWith(@" + argument++.ToString() + ")";
                            break;

                        case "equal":
                            arguments.Add(value);
                            linq = field + " == @" + argument++.ToString();
                            //linq = field + ".Equals(@" + argument++.ToString() + ")"; // NULLABLES do not support Equals()
                            break;

                        case "greaterthan":
                            arguments.Add(value);
                            linq = field + " > @" + argument++.ToString();
                            //linq = field + ".CompareTo(@" + argument++.ToString() + ") > 0"; // NULLABLES do not support CompareTo()
                            break;

                        case "greaterthanorequal":
                            arguments.Add(value);
                            linq = field + " >= @" + argument++.ToString();
                            //linq = field + ".CompareTo(@" + argument++.ToString() + ") >= 0"; // NULLABLES do not support CompareTo()
                            break;

                        case "lessthan":
                            arguments.Add(value);
                            linq = field + " < @" + argument++.ToString();
                            //linq = field + ".CompareTo(@" + argument++.ToString() + ") < 0"; // NULLABLES do not support CompareTo()
                            break;

                        case "lessthanorequal":
                            arguments.Add(value);
                            linq = field + " <= @" + argument++.ToString();
                            //linq = field + ".CompareTo(@" + argument++.ToString() + ") <= 0"; // NULLABLES do not support CompareTo()
                            break;

                        case "notequal":
                            arguments.Add(value);
                            linq = field + " != @" + argument++.ToString();
                            //linq = "!" + field + ".Equals(@" + argument++.ToString() + ")"; // NULLABLES do not support Equals()
                            break;

                        case "startswith": // String
                            arguments.Add(value);
                            linq = field + ".StartsWith(@" + argument++.ToString() + ")";
                            break;

                        default:
                            arguments.Add(value);
                            linq = field + " == @" + argument++.ToString();
                            break;
                    }
                }
                else
                {
                    // ej.FilterOperators
                    switch (whereOperator.ToLower())
                    {
                        case "equal":
                            linq = field + " == null";
                            break;


                        case "notequal":
                            linq = field + " != null";
                            break;
                    }
                }            
            }

            return linq;
        }

        #endregion Methods Sycnfusion.Javascript.DataManager - Where

        #region Methods Sycnfusion.Javascript.DataManager - Sort

        private string SortToLinq(List<Sort> sorts)
        {
            string orderBy = "";

            if (sorts != null)
            {
                foreach (Sort sort in sorts)
                {
                    string linq = SortExpressionToLinq(sort.Name, sort.Direction);
                    if (linq != "")
                    {
                        orderBy = orderBy != "" ? orderBy + ", " : orderBy;
                        orderBy += linq;
                    }
                }
            }

            return orderBy;
        }

        private string SortExpressionToLinq(string field, string orderByDirection)
        {
            string direction;

            switch (orderByDirection)
            {
                case "ascending":
                    direction = "";
                    break;

                case "descending":
                    direction = "desc";
                    break;

                default:
                    direction = "";
                    break;
            }

            return LookupTextToLINQOrderBy(field, direction); ;
        }

        #endregion Methods Sycnfusion.Javascript.DataManager - Sort

        #region Methods Sycnfusion.Javascript.DataManager - LookupText

        private string LookupTextToWhere(string field)
        {
            string result = field;

            if (field.EndsWith("LookupText"))
            {
                if (HasServerSideJoins)
                {
                    // field                        entityLINQ      entity1         words               entity2             entityType                    

                    // EmployeeLookupText           Employee        Employee        Employee            Employee            Employee
                    // EmployeeAreaLookupText       EmployeeArea    EmployeeArea    Employee Area       Employee            EmployeeArea

                    // Employee1LookupText          Employee1       Employee1       Employee 1          Employee            Employee
                    // EmployeeArea1LookupText      EmployeeArea1   EmployeeArea1   Employee Area 1     EmployeeArea        EmployeeArea

                    // EmployeeXLookupText          EmployeeX       EmployeeX       Employee X          Employee            Employee
                    // EmployeeAreaXLookupText      EmployeeAreaX   EmployeeAreaX   Employee Area X     EmployeeArea        EmployeeArea

                    field = field.Replace("LookupText", "");
                    string entityLINQ = field;

                    //int underscore = field.IndexOf("_");
                    //if (underscore >= 0)
                    //{
                    //    field = field.Left(underscore);
                    //}

                    string entity1 = field;
                    string entity2 = "";
                    string[] words = CodeSmithHelper.StringSplitPascalCase(field).Split(' ');
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        entity2 += words[i];
                    }

                    System.Type entityType = LibraryHelper.GetType(DataNamespace + "." + entity1);
                    if (entityType == null)
                    {
                        entityType = LibraryHelper.GetType(DataNamespace + "." + entity2);
                    }

                    if (entityType == null)
                    {
                        result = "";
                    }
                    else
                    {
                        IZProfile profile = DataHelper.GetProfile(entityType);
                        result = entityLINQ + "." + profile.Lookup;
                    }
                }
                else
                {
                    result = "";
                }
            }

            return result;
        }

        private string LookupTextToLINQOrderBy(string field, string direction)
        {
            string result = field + " " + direction;

            if (field.EndsWith("LookupText"))
            {
                if (HasServerSideJoins)
                {
                    // field                        entityLINQ      entity1         words               entity2             entityType                    

                    // EmployeeLookupText           Employee        Employee        Employee            Employee            Employee
                    // EmployeeAreaLookupText       EmployeeArea    EmployeeArea    Employee Area       Employee            EmployeeArea

                    // Employee1LookupText          Employee1       Employee1       Employee 1          Employee            Employee
                    // EmployeeArea1LookupText      EmployeeArea1   EmployeeArea1   Employee Area 1     EmployeeArea        EmployeeArea

                    // EmployeeXLookupText          EmployeeX       EmployeeX       Employee X          Employee            Employee
                    // EmployeeAreaXLookupText      EmployeeAreaX   EmployeeAreaX   Employee Area X     EmployeeArea        EmployeeArea

                    field = field.Replace("LookupText", "");
                    string entityLINQ = field;

                    //int underscore = field.IndexOf("_");
                    //if (underscore >= 0)
                    //{
                    //    field = field.Left(underscore);
                    //}

                    string entity1 = field;
                    string entity2 = "";
                    string[] words = CodeSmithHelper.StringSplitPascalCase(field).Split(' ');
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        entity2 += words[i];
                    }

                    System.Type entityType = LibraryHelper.GetType(DataNamespace + "." + entity1);
                    if (entityType == null)
                    {
                        entityType = LibraryHelper.GetType(DataNamespace + "." + entity2);
                    }

                    if (entityType == null)
                    {
                        result = "";
                    }
                    else
                    {
                        IZProfile profile = DataHelper.GetProfile(entityType);
                        result = entityLINQ + "." + profile.LINQOrderBy + " " + direction;
                    }
                }
                else
                {
                    result = "";
                }
            }

            return result;
        }

        #endregion Methods Sycnfusion.Javascript.DataManager - LookupText
    }

    public class SyncfusionDataResult
    {
        #region Properties

        public IEnumerable result { get; set; }

        public int count { get; set; }

        public IEnumerable aggregate { get; set; }

        #endregion Properties

        #region Methods

        public SyncfusionDataResult()
        {
            this.count = 0;
            this.aggregate = new List<object>();
        }

        #endregion Methods
    }
}