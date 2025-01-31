using Northwind.Application;
using Northwind.Data;
using Northwind.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Northwind.Mvc
{
    public partial class EmployeeController : BaseMvcControllerSCRUDApplication<Employee>
    {
        #region Methods

        public EmployeeController(INorthwindGenericApplication<Employee> application)
    : base(application.AuthorizationManager)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Employee
        // GET: Employee/Index
        [HttpGet]
        public ActionResult Index(string operation = null)
        {
            EmployeeCollectionModel employeeCollectionModel = new EmployeeCollectionModel(ActivityOperations, "Index", null, null, null, operation);

            try
            {
                if (IsIndex(employeeCollectionModel.OperationResult))
                {
                    return ZView(employeeCollectionModel);
                }
            }
            catch (Exception exception)
            {
                employeeCollectionModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(employeeCollectionModel.OperationResult);
        }        

        // GET & POST: Employee/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, string masterEntity = null, string masterKey = null)
        {
            EmployeeCollectionModel employeeCollectionModel = new EmployeeCollectionModel(ActivityOperations, "Search", masterControllerAction, masterEntity, masterKey);

            try
            {
                if (IsOperation(employeeCollectionModel.OperationResult))
                {
                    return ZPartialView(employeeCollectionModel);
                }
            }
            catch (Exception exception)
            {
                employeeCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeCollectionModel.OperationResult);
        }

        // GET & POST: Employee/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, bool? required = false, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, required, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return ZPartialView("_EmployeeLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Employee/Create
        [HttpGet]
        public ActionResult Create(string masterEntity = null, string masterKey = null)
        {
            EmployeeItemModel employeeItemModel = new EmployeeItemModel(ActivityOperations, "Create", masterEntity, masterKey);

            try
            {
                if (IsCreate(employeeItemModel.OperationResult))
                {
                    return ZPartialView("CRUD", employeeItemModel);
                }            
            }
            catch (Exception exception)
            {
                employeeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeItemModel.OperationResult);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeItemModel employeeItemModel)
        {
            try
            {
                if (IsCreate(employeeItemModel.OperationResult))
                {
                    if (IsValid(employeeItemModel.OperationResult, employeeItemModel.Employee))
                    {
                        Employee employee = (Employee)employeeItemModel.Employee.ToData();
                        if (Application.Create(employeeItemModel.OperationResult, employee))
                        {
                            if (employeeItemModel.IsSave)
                            {
                                Create2Update(employeeItemModel.OperationResult);
                                return JsonResultSuccess(employeeItemModel.OperationResult,
                                    Url.Action("Update", "Employee", new { EmployeeId = employee.EmployeeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(employeeItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                employeeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeItemModel.OperationResult);
        }

        // GET: Employee/Read/1
        [HttpGet]
        public ActionResult Read(int employeeId, string masterEntity = null, string masterKey = null)
        {
            EmployeeItemModel employeeItemModel = new EmployeeItemModel(ActivityOperations, "Read", masterEntity, masterKey);
            
            try
            {
                if (IsRead(employeeItemModel.OperationResult))
                {
                    Employee employee = Application.GetById(employeeItemModel.OperationResult, new object[] { employeeId }, true);
                    if (employee != null)
                    {
                        employeeItemModel.Employee = new EmployeeViewModel(employee);                    

                        return ZPartialView("CRUD", employeeItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(employeeItemModel.OperationResult);
        }

        // GET: Employee/Update/1
        [HttpGet]
        public ActionResult Update(int employeeId, string masterEntity = null, string masterKey = null)
        {
            EmployeeItemModel employeeItemModel = new EmployeeItemModel(ActivityOperations, "Update", masterEntity, masterKey);
            
            try
            {
                if (IsUpdate(employeeItemModel.OperationResult))
                {            
                    Employee employee = Application.GetById(employeeItemModel.OperationResult, new object[] { employeeId }, true);
                    if (employee != null)
                    {
                        employeeItemModel.Employee = new EmployeeViewModel(employee);

                        return ZPartialView("CRUD", employeeItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeItemModel.OperationResult);
        }

        // POST: Employee/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeItemModel employeeItemModel)
        {
            try
            {
                if (IsUpdate(employeeItemModel.OperationResult))
                {
                    if (IsValid(employeeItemModel.OperationResult, employeeItemModel.Employee))
                    {
                        Employee employee = (Employee)employeeItemModel.Employee.ToData();
                        if (Application.Update(employeeItemModel.OperationResult, employee))
                        {
                            if (employeeItemModel.IsSave)
                            {
                                return JsonResultSuccess(employeeItemModel.OperationResult,
                                    Url.Action("Update", "Employee", new { EmployeeId = employee.EmployeeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(employeeItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                employeeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeItemModel.OperationResult);
        }

        // GET: Employee/Delete/1
        [HttpGet]
        public ActionResult Delete(int employeeId, string masterEntity = null, string masterKey = null)
        {
            EmployeeItemModel employeeItemModel = new EmployeeItemModel(ActivityOperations, "Delete", masterEntity, masterKey);
            
            try
            {
                if (IsDelete(employeeItemModel.OperationResult))
                {            
                    Employee employee = Application.GetById(employeeItemModel.OperationResult, new object[] { employeeId }, true);
                    if (employee != null)
                    {
                        employeeItemModel.Employee = new EmployeeViewModel(employee);

                        return ZPartialView("CRUD", employeeItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeItemModel.OperationResult);
        }

        // POST: Employee/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeItemModel employeeItemModel)
        {
            try
            {
                if (IsDelete(employeeItemModel.OperationResult))
                {
                    if (Application.Delete(employeeItemModel.OperationResult, (Employee)employeeItemModel.Employee.ToData()))
                    {
                        return JsonResultSuccess(employeeItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                employeeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Employee/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult
            {
                result = new List<EmployeeViewModel>()
            };

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Employee), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewModelHelper<EmployeeViewModel, Employee>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
                    if (dataManager.RequiresCounts)
                    {
                        dataResult.count = Application.Count(operationResult, where, args.ToArray());
                    }
                }
                catch (Exception exception)
                {
                    operationResult.ParseException(exception);
                }
            }

            if (!operationResult.Ok)
            {
                operationResult.ThrowException();
            }

            return Json(JsonConvert.SerializeObject(dataResult), JsonRequestBehavior.AllowGet);
        } 

        // POST: Employee/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, EmployeeResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Employee/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, EmployeeResources.EntitySingular + ".pdf");
            }
        }

        // POST: Employee/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, EmployeeResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}