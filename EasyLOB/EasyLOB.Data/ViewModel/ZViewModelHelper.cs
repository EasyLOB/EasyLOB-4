using System.Collections.Generic;

namespace EasyLOB.Data
{
    /// <summary>
    /// ZViewModel Helper.
    /// </summary>
    /// <typeparam name="TEntityView">View type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public static partial class ZViewModelHelper<TEntityView, TEntity>
        where TEntityView : class, IZViewModel<TEntityView, TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        /// <summary>
        /// Convert data list to view list.
        /// </summary>
        /// <param name="dataModels"></param>
        /// <returns></returns>
        public static List<TEntityView> ToViewList(List<TEntity> dataModels) // List<DataModel> -> List<ViewModel>
        {
            return EasyLOBHelper.Mapper.Map<List<TEntity>, List<TEntityView>>(dataModels);
        }
        //public static List<TEntityView> ToViewList(IEnumerable<TEntity> dataModels) // List<DataModel> -> List<ViewModel>
        //{
        //    List<TEntityView> viewModels = new List<TEntityView>();

        //    foreach (TEntity dataModel in dataModels)
        //    {
        //        viewModels.Add((TEntityView)Activator.CreateInstance(typeof(TEntityView), dataModel));
        //    }

        //    return viewModels;
        //}

        /// <summary>
        /// Convert view list to data list.
        /// </summary>
        /// <param name="viewModels"></param>
        /// <returns></returns>
        public static List<TEntity> ToDataList(List<TEntityView> viewModels) // List<ViewModel> -> List<DataModel>
        {
            return EasyLOBHelper.Mapper.Map<List<TEntityView>, List<TEntity>>(viewModels);
        }
        //public static List<TEntity> ToDataList(IEnumerable<TEntityView> viewModels) // List<ViewModel> -> List<DataModel>
        //{
        //    List<TEntity> dataModels = new List<TEntity>();

        //    foreach (TEntityView viewModel in viewModels)
        //    {
        //        dataModels.Add(viewModel.ToData() as TEntity);
        //    }

        //    return dataModels;
        //}

        #endregion Methods
    }
}