namespace EasyLOB
{
    /// <summary>
    /// IZDTOModel.
    /// </summary>
    /// <typeparam name="TEntityDTO">DTO type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public interface IZDTOModel<TEntityDTO, TEntity>
    {
        #region Properties

        /// <summary>
        /// Lookup text.
        /// </summary>
        string LookupText { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Clone object.
        /// </summary>
        /// <returns></returns>
        object CloneShallow();

        /// <summary>
        /// Convert data entity do DTO entity.
        /// </summary>
        /// <param name="dataModel">Data entity</param>
        void FromData(IZDataModel dataModel);

        /// <summary>
        /// On constructor ( called from Constructor ).
        /// </summary>
        void OnConstructor();

        /// <summary>
        /// Convert to data entity.
        /// </summary>
        /// <returns></returns>
        IZDataModel ToData();

        #endregion Methods
    }
}