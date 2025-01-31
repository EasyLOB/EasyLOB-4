using EasyLOB;
using EasyLOB.Data;
using System;
using System.Reflection;

namespace Northwind.Data
{
    public static class NorthwindDataHelper
    {
        #region Methods

        public static void SetupProfiles(string dataAssemblyName)
        {
            /*
            Assembly.Load(dataAssemblyName);
            Assembly dataAssembly = LibraryHelper.GetAssembly(dataAssemblyName);

            Type baseType = typeof(ZDataModel);
            Type[] types = dataAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(baseType))
                {
                    ZProfile profile = DataHelper.GetProfile(type);

                    // Class

                    switch (type.Name)
                    {
                        case "Order":
                            profile.Associations.Add("Product.Category");
                            break;
                    }

                    // Property

                    foreach (ZProfileProperty property in profile.Properties)
                    {
                        if (property.Name.ToLower() == "?")
                        {
                            property.IsGridVisible = false;
                            //property.IsEditReadOnly = true;
                            property.IsEditVisible = false;
                        }
                    }
                }
            }
            */
        }

        #endregion Methods
    }
}