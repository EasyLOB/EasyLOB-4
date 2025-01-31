using System.Collections.Generic;

namespace EasyLOB.Data
{
    /// <summary>
    /// ZViewModel Helper.
    /// </summary>
    /// <typeparam name="TEntityView">View type</typeparam>
    /// <typeparam name="TEntityDTO">DTO type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public static partial class ZViewModelHelper<TEntityView, TEntityDTO, TEntity>
    where TEntityView : class, IZViewModel<TEntityView, TEntityDTO, TEntity>
    where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
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
        /// Convert DTO list to view list.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<TEntityView> ToViewList(List<TEntityDTO> dtos) // List<DTO> -> List<ViewModel>
        {
            return EasyLOBHelper.Mapper.Map<List<TEntityDTO>, List<TEntityView>>(dtos);
        }
        //public static List<TEntityView> ToViewList(IEnumerable<TEntityDTO> dtos) // List<DTO> -> List<ViewModel>
        //{
        //    List<TEntityView> viewModels = new List<TEntityView>();

        //    foreach (TEntityDTO dto in dtos)
        //    {
        //        viewModels.Add((TEntityView)Activator.CreateInstance(typeof(TEntityView), dto));
        //    }

        //    return viewModels;
        //}

        /// <summary>
        /// Convert view list to DTO list.
        /// </summary>
        /// <param name="viewModels"></param>
        /// <returns></returns>
        public static List<TEntityDTO> ToDTOList(List<TEntityView> viewModels) // List<ViewModel> -> List<DTO>
        {
            return EasyLOBHelper.Mapper.Map<List<TEntityView>, List<TEntityDTO>>(viewModels);
        }
        //public static List<TEntityDTO> ToDTOList(IEnumerable<TEntityView> viewModels) // List<ViewModel> -> List<DTO>
        //{
        //    List<TEntityDTO> dtos = new List<TEntityDTO>();

        //    foreach (TEntityView viewModel in viewModels)
        //    {
        //        dtos.Add(viewModel.ToDTO() as TEntityDTO);
        //    }

        //    return dtos;
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