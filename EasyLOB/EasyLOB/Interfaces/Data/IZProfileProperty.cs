namespace EasyLOB
{
    /// <summary>
    /// IZProfileProperty.
    /// </summary>
    public interface IZProfileProperty
    {
        #region Properties

        /// <summary>
        /// Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Is key ?
        /// </summary>
        bool IsKey { get; set; }

        /// <summary>
        /// Is identity ?
        /// </summary>
        bool IsIdentity { get; set; }
        /*
        /// <summary>
        /// Is required Data Model ?
        /// </summary>
        bool IsRequiredData { get; set; }
        */
        /// <summary>
        /// Is required View Model ?
        /// </summary>
        bool IsRequiredView { get; set; }

        /// <summary>
        /// Is attribute required ?
        /// </summary>
        bool IsAttributeRequired { get; set; }

        #endregion Properties

        #region Properties Edit

        /// <summary>
        /// Is edit visible ?
        /// </summary>
        bool IsEditVisible { get; set; }

        /// <summary>
        /// Is edit read-only ?
        /// </summary>
        bool IsEditReadOnly { get; set; }

        /// <summary>
        /// Is edit required ?
        /// </summary>
        bool IsEditRequired { get; set; }

        /// <summary>
        /// Edit CSS.
        /// </summary>
        string EditCSS { get; set; }

        #endregion Properties Edit

        #region Properties Grid

        /// <summary>
        /// Is grid visible ?
        /// </summary>
        bool IsGridVisible { get; set; }

        /// <summary>
        /// Is search ?
        /// </summary>
        bool IsGridSearch { get; set; }

        /// <summary>
        /// Grid width.
        /// </summary>
        int GridWidth { get; set; }

        #endregion Properties Grid
    }
}