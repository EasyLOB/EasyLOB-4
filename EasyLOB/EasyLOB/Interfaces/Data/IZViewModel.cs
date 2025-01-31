namespace EasyLOB
{
    /// <summary>
    /// IZViewModel.
    /// </summary>
    /// <typeparam name="TEntityView">View type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public interface IZViewModel<TEntityView, TEntity>
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
        /// Convert data entity to view entity.
        /// </summary>
        /// <param name="dataModel">Data entity</param>
        void FromData(IZDataModel dataModel);

        void OnConstructor();

        /// <summary>
        /// Convert view entity to data entity.
        /// </summary>
        /// <returns></returns>
        IZDataModel ToData();

        #endregion Methods
    }
}