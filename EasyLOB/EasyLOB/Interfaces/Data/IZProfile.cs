using System;
using System.Collections.Generic;

namespace EasyLOB
{
    /// <summary>
    /// IZProfile.
    /// </summary>
    public interface IZProfile
    {
        #region Properties

        /// <summary>
        /// Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Is identity ?
        /// </summary>
        bool IsIdentity { get; set; }

        /// <summary>
        /// Key properties.
        /// </summary>
        List<string> Keys { get; }

        /// <summary>
        /// Lookup property.
        /// </summary>
        string Lookup { get; set; }

        /// <summary>
        /// Order by clause.
        /// </summary>
        string LINQOrderBy { get; set; }

        /// <summary>
        /// Where clause.
        /// </summary>
        string LINQWhere { get; set; }

        //bool IsLog { get; set; }

        //bool IsSearch { get; set; }

        //int RecordsByLookup { get; set; }

        //int RecordsByPage { get; set; }

        //int RecordsBySearch { get; set; }

        string TypeFullName { get; set; }
        
        /// <summary>
        /// Associations.
        /// </summary>
        List<string> Associations { get; }

        /// <summary>
        /// Collections.
        /// </summary>
        Dictionary<string, bool> Collections { get; }

        /// <summary>
        /// Properties.
        /// </summary>
        List<IZProfileProperty> Properties { get; }

        #endregion Properties

        #region Properties Edit

        /// <summary>
        /// Edit collections.
        /// </summary>
        List<string> EditCollections { get; }

        /// <summary>
        /// Edit hidden collections.
        /// </summary>
        List<string> EditHiddenCollections { get; }

        /// <summary>
        /// Edit hidden properties.
        /// </summary>
        List<string> EditHiddenProperties { get; }

        /// <summary>
        /// Edit read-only properties.
        /// </summary>
        List<string> EditReadOnlyProperties { get; }

        /// <summary>
        /// Edit required properties.
        /// </summary>
        List<string> EditRequiredProperties { get; }

        #endregion Properties Helper Edit

        #region Properties Grid

        /// <summary>
        /// Grid properties.
        /// </summary>
        List<string> GridProperties { get; }

        /// <summary>
        /// Grid search properties.
        /// </summary>
        List<string> GridSearchProperties { get; }

        #endregion Properties Helper Grid

        #region Methods

        /// <summary>
        /// Get profile property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        IZProfileProperty GetProfileProperty(string propertyName);

        /// <summary>
        /// Get resource.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        string GetResource(string resource);

        /// <summary>
        /// Is required view model ?
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        bool IsRequiredView(string propertyName);

        /// <summary>
        /// Set edit read-only.
        /// </summary>
        /// <param name="value">Value</param>
        void SetEditReadOnly(bool value);

        /// <summary>
        /// Set edit required.
        /// </summary>
        /// <param name="value">Value</param>
        void SetEditRequired(bool value);

        /// <summary>
        /// Set edit visible.
        /// </summary>
        /// <param name="value">Value</param>
        void SetEditVisible(bool value);

        /// <summary>
        /// Set grid search.
        /// </summary>
        /// <param name="value">Value</param>
        void SetGridSearch(bool value);

        /// <summary>
        /// Set grid visible.
        /// </summary>
        /// <param name="value">Value</param>
        void SetGridVisible(bool value);

        /// <summary>
        /// Set profile property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="isGridVisible">Is grid visible ?</param>
        /// <param name="isGridSearch">Is grid search ?</param>
        /// <param name="gridWidth">Grid width</param>
        /// <param name="isEditVisible">Is edit visible ?</param>
        /// <param name="isEditReadOnly">Is edit read-only ?</param>
        /// <param name="isEditRequired">Is edit required ?</param>
        /// <param name="editCSS">Edit CSS</param>
        void SetProfileProperty(string propertyName,
            bool? isGridVisible = null,
            bool? isGridSearch = null,
            int? gridWidth = null,
            bool? isEditVisible = null,
            bool? isEditReadOnly = null,
            bool? isEditRequired = null,
            string editCSS = null);

        #endregion Methods

        #region Methods Edit

        /// <summary>
        /// Edit CSS for property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        string EditCSSFor(string propertyName);

        /// <summary>
        /// Edit CSS Group for property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        string EditCSSGroupFor(string propertyName);

        /// <summary>
        /// Edit CSS Editor for property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        string EditCSSEditorFor(string propertyName);

        /// <summary>
        /// Edit CSS Editor Date for property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        string EditCSSEditorDateFor(string propertyName);

        /// <summary>
        /// Edit CSS Editor DateTime for property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        string EditCSSEditorDateTimeFor(string propertyName);

        /// <summary>
        /// Edit CSS Label for property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        string EditCSSLabelFor(string propertyName);

        /// <summary>
        /// Edit CSS Lookup Editor.
        /// </summary>
        /// <param name="required">Required ?</param>
        /// <returns></returns>
        string EditCSSLookupEditor(bool required);

        /// <summary>
        /// Is collection visible ?
        /// </summary>
        /// <param name="collectionName">Collection name</param>
        /// <returns></returns>
        bool IsCollectionVisibleFor(string collectionName);

        #endregion Methods Edit

        #region Methods Grid

        /// <summary>
        /// Is grid visible ?
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        bool IsGridVisibleFor(string propertyName);

        /// <summary>
        /// Grid width.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        int GridWidthFor(string propertyName);

        #endregion Methods Grid
    }
}
 