using EasyLOB.Resources;
using System;
using System.Collections;

namespace EasyLOB.Mvc
{
    public class BaseMvcControllerSCRUDPersistence<TEntity> : BaseMvcControllerSCRUD<TEntity>
        where TEntity : class, IZDataModel
    {
        #region Properties

        protected override string Entity
        {
            get { return Repository.Entity; }
        }

        protected IUnitOfWork UnitOfWork { get; set; }

        protected IGenericRepository<TEntity> Repository { get { return UnitOfWork.GetRepository<TEntity>(); } }

        #endregion Properties

        #region Methods

        public BaseMvcControllerSCRUDPersistence(IAuthorizationManager authorizationManager)
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
                if (IsExport(operationResult) && IsSearch(operationResult))
                {
                    IEnumerable data = Repository.SearchAll();
                    SyncfusionGrid.ExportToExcel(gridModel, data, fileName, AppDefaults.SyncfusionTheme);
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
                if (IsExport(operationResult) && IsSearch(operationResult))
                {
                    IEnumerable data = Repository.SearchAll();
                    SyncfusionGrid.ExportToPdf(gridModel, data, fileName, AppDefaults.SyncfusionTheme);
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
                if (IsExport(operationResult) && IsSearch(operationResult))
                {
                    IEnumerable data = Repository.SearchAll();
                    SyncfusionGrid.ExportToWord(gridModel, data, fileName, AppDefaults.SyncfusionTheme);
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