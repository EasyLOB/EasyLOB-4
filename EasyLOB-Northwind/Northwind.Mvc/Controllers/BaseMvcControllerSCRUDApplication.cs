using EasyLOB.Resources;
using System;
using System.Collections;

namespace EasyLOB.Mvc
{
    public class BaseMvcControllerSCRUDApplication<TEntity> : BaseMvcControllerSCRUD<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Properties

        protected override string Entity
        {
            get { return Application.Repository.Entity; }
        }

        protected IGenericApplication<TEntity> Application { get; set; }

        #endregion Properties

        #region Methods

        public BaseMvcControllerSCRUDApplication(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods

        #region Methods Syncfusion

        protected void ExportToExcel(string gridModel, string fileName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsExport(operationResult))
                {
                    IEnumerable data = Application.SearchAll(operationResult);
                    if (operationResult.Ok)
                    {
                        SyncfusionGrid.ExportToExcel(gridModel, data, fileName, AppDefaults.SyncfusionTheme);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            if (!operationResult.Ok)
            {
                gridModel = "{\"columns\":[{\"field\":\"Message\",\"headerText\":\"" + ErrorResources.Error + "\"}]}";
                SyncfusionGrid.ExportToExcel(gridModel, operationResult.ToDataSet(), fileName, AppDefaults.SyncfusionTheme);
            }
        }

        protected void ExportToPdf(string gridModel, string fileName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsExport(operationResult))
                {
                    IEnumerable data = Application.SearchAll(operationResult);
                    if (operationResult.Ok)
                    {
                        SyncfusionGrid.ExportToPdf(gridModel, data, fileName, AppDefaults.SyncfusionTheme);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            if (!operationResult.Ok)
            {
                gridModel = "{\"columns\":[{\"field\":\"Message\",\"headerText\":\"" + ErrorResources.Error + "\"}]}";
                SyncfusionGrid.ExportToPdf(gridModel, operationResult.ToDataSet(), fileName, AppDefaults.SyncfusionTheme);
            }
        }

        protected void ExportToWord(string gridModel, string fileName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsExport(operationResult))
                {
                    IEnumerable data = Application.SearchAll(operationResult);
                    if (operationResult.Ok)
                    {
                        SyncfusionGrid.ExportToWord(gridModel, data, fileName, AppDefaults.SyncfusionTheme);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            if (!operationResult.Ok)
            {
                gridModel = "{\"columns\":[{\"field\":\"Message\",\"headerText\":\"" + ErrorResources.Error + "\"}]}";
                SyncfusionGrid.ExportToWord(gridModel, operationResult.ToDataSet(), fileName, AppDefaults.SyncfusionTheme);
            }
        }

        #endregion Methods Syncfusion
    }
}