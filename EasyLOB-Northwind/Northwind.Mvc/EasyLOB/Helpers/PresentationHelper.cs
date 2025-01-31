using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;

namespace EasyLOB
{
    public static class PresentationHelper
    {
        #region Methods

        public static bool ZViewModelValidate(ZOperationResult operationResult, Type type, object viewModel)
        {
            IZProfile profile = DataHelper.GetProfile(type);
            if (profile != null)
            {
                foreach (string property in profile.EditRequiredProperties)
                {
                    try
                    {
                        object value = LibraryHelper.GetPropertyValue(viewModel, property);
                        if (value == null || (value is string && string.IsNullOrEmpty((string)value)))
                        {
                            operationResult.AddOperationWarning("",
                                string.Format("[ {0} ] {1}", profile.GetResource("Property" + property), ErrorResources.Required));
                        }
                    }
                    catch { }
                }
            }

            return operationResult.Ok;
        }

        #endregion Methods

        #region Methods ZOperationResult

        public static void Data(ZOperationResult operationResult, string data = null)
        {
            operationResult.Data = data ?? "EasyLOB";
        }

        public static void Exception(ZOperationResult operationResult)
        {
            try
            {
                int x = Convert.ToInt32("Error");
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }
        }

        public static void Error(ZOperationResult operationResult)
        {
            operationResult.ErrorCode = "1";
            operationResult.ErrorMessage = "Error 1";
            operationResult.AddOperationError("2", "Error 2");
            operationResult.AddOperationError("3", "Error 3");
        }

        public static void Information(ZOperationResult operationResult)
        {
            operationResult.InformationCode = "1";
            operationResult.InformationMessage = "Information 1";
            operationResult.AddOperationInformation("2", "Information 2");
            operationResult.AddOperationInformation("3", "Information 3");
        }

        public static void Warning(ZOperationResult operationResult)
        {
            operationResult.WarningCode = "1";
            operationResult.WarningMessage = "Warning 1";
            operationResult.AddOperationWarning("2", "Warning 2");
            operationResult.AddOperationWarning("3", "Warning 3");
        }

        #endregion Methods ZOperationResult
    }
}