using System.Collections.Generic;

namespace EasyLOB.Data
{
    /// <summary>
    /// ZDTOModel Helper.
    /// </summary>
    /// <typeparam name="TEntityDTO">DTO type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public static partial class ZDTOModelHelper<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
        #region Methods

        /// <summary>
        /// Convert data list to DTO list.
        /// </summary>
        /// <param name="dataModels">Data list</param>
        /// <returns></returns>
        public static List<TEntityDTO> ToDTOList(List<TEntity> dataModels) // List<DataModel> -> List<DTO>
        {
            return EasyLOBHelper.Mapper.Map<List<TEntity>, List<TEntityDTO>>(dataModels);
        }
        //public static List<TEntityDTO> ToDTOList(IEnumerable<TEntity> dataModels) // List<DataModel> -> List<DTO>
        //{
        //    List<TEntityDTO> dtos = new List<TEntityDTO>();

        //    foreach (TEntity dataModel in dataModels)
        //    {
        //        dtos.Add((TEntityDTO)Activator.CreateInstance(typeof(TEntityDTO), dataModel));
        //    }

        //    return dtos;
        //}

        /// <summary>
        /// Convert DTO list to data list.
        /// </summary>
        /// <param name="dtos">DTO list</param>
        /// <returns></returns>
        public static List<TEntity> ToDataList(List<TEntityDTO> dtos) // List<DTO> -> List<DataModel>
        {
            return EasyLOBHelper.Mapper.Map<List<TEntityDTO>, List<TEntity>>(dtos);
        }
        //public static List<TEntity> ToDataList(IEnumerable<TEntityDTO> dtos) // List<DTO> -> List<DataModel>
        //{
        //    List<TEntity> dataModels = new List<TEntity>();

        //    foreach (TEntityDTO dto in dtos)
        //    {
        //        dataModels.Add(dto.ToData() as TEntity);
        //    }

        //    return dataModels;
        //}

        #endregion Methods
    }
}