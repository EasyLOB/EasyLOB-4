using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

// ZProfile
//     IsRequiredView(property) = property.IsRequiredView
// ZProfileProperty
//         IsRequiredData
//         IsRequiredView = IsAttributeRequired || IsEditRequired
//             IsAttributeRequired
//             IsEditRequired

namespace EasyLOB.Data
{
    [DataContract]
    [Serializable]
    public class ZProfile : IZProfile
    {
        #region Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsIdentity { get; set; }

        [DataMember]
        public List<string> Keys { get; }

        [DataMember]
        public string Lookup { get; set; }

        [DataMember]
        public string LINQOrderBy { get; set; }

        [DataMember]
        public string LINQWhere { get; set; }

        //[DataMember]
        //public bool IsLog { get; set; }

        //[DataMember]
        //public bool IsSearch { get; set; }

        //[DataMember]
        //public int RecordsByLookup { get; set; }

        //[DataMember]
        //public int RecordsByPage { get; set; }

        //[DataMember]
        //public int RecordsBySearch { get; }

        [DataMember]
        public string TypeFullName { get; set; }

        [DataMember]
        public List<string> Associations { get; }

        [DataMember]
        public Dictionary<string, bool> Collections { get; }

        [DataMember]
        public List<IZProfileProperty> Properties { get; }

        #endregion Properties

        #region Properties Edit

        [DataMember]
        public List<string> EditCollections
        {
            get
            {
                List<string> result = new List<string>();

                foreach(KeyValuePair<string, bool> keyValue in Collections)
                {
                    if (keyValue.Value)
                    {
                        result.Add(keyValue.Key);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> EditHiddenCollections
        {
            get
            {
                List<string> result = new List<string>();

                foreach (KeyValuePair<string, bool> keyValue in Collections)
                {
                    if (!keyValue.Value)
                    {
                        result.Add(keyValue.Key);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> EditHiddenProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (!profileProperty.IsEditVisible)
                    {
                        result.Add(profileProperty.Name);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> EditReadOnlyProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (profileProperty.IsEditReadOnly)
                    {
                        result.Add(profileProperty.Name);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> EditRequiredProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (profileProperty.IsRequiredView || profileProperty.IsEditRequired)
                    {
                        result.Add(profileProperty.Name);
                    }
                }

                return result;
            }
        }

        #endregion Properties Edit

        #region Properties Grid

        [DataMember]
        public List<string> GridProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (profileProperty.IsGridVisible)
                    {
                        result.Add(profileProperty.Name);
                    }
                }

                return result;
            }
        }

        [DataMember]
        public List<string> GridSearchProperties
        {
            get
            {
                List<string> result = new List<string>();

                foreach (ZProfileProperty profileProperty in Properties)
                {
                    if (profileProperty.IsGridSearch)
                    {
                        result.Add(profileProperty.Name);
                    }
                }

                return result;
            }
        }

        #endregion Properties Grid

        #region Methods

        public ZProfile()
        {
            Keys = new List<string>();
            Associations = new List<string>();
            Collections = new Dictionary<string, bool>();
            Properties = new List<IZProfileProperty>();
        }

        public IZProfileProperty GetProfileProperty(string propertyName)
        {
            return Properties
                .Where(x => x.Name == propertyName)
                .FirstOrDefault();
        }

        public string GetResource(string resource)
        {
            return DataHelper.GetResource(LibraryHelper.GetType(TypeFullName), resource);
        }
        /*
        public bool IsRequiredData(string propertyName)
        {
            bool result = false;

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result = profileProperty.IsRequiredData;
            }

            return result;
        }
        */
        public bool IsRequiredView(string propertyName)
        {
            bool result = false;

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result = profileProperty.IsRequiredView;
            }

            return result;
        }

        public void SetCollections(bool value)
        {
            foreach (string key in Collections.Keys.ToList())
            {
                Collections[key] = value;
            }

            //foreach (KeyValuePair<string, bool> keyValue in Collections)
            //{
            //    Collections[keyValue.Key] = false;
            //}
        }

        public void SetEditReadOnly(bool value)
        {
            foreach (IZProfileProperty property in Properties)
            {
                property.IsEditReadOnly = value;
            }
        }

        public void SetEditRequired(bool value)
        {
            foreach (IZProfileProperty property in Properties)
            {
                property.IsEditRequired = value;
            }
        }

        public void SetEditVisible(bool value)
        {
            foreach (IZProfileProperty property in Properties)
            {
                property.IsEditVisible = value;
            }
        }

        public void SetGridSearch(bool value)
        {
            foreach (IZProfileProperty property in Properties)
            {
                property.IsGridSearch = value;
            }
        }

        public void SetGridVisible(bool value)
        {
            foreach (IZProfileProperty property in Properties)
            {
                property.IsGridVisible = value;
            }
        }

        public void SetProfileProperty(string propertyName,
            bool? isGridVisible = null,
            bool? isGridSearch = null,
            int? gridWidth = null,
            bool? isEditVisible = null,
            bool? isEditReadOnly = null,
            bool? isEditRequired = null,
            string editCSS = null)
        {
            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                if (isGridVisible != null)
                {
                    profileProperty.IsGridVisible = (bool)isGridVisible;
                }

                if (isGridSearch != null)
                {
                    profileProperty.IsGridSearch = (bool)isGridSearch;
                }

                if (gridWidth != null)
                {
                    profileProperty.GridWidth = (int)gridWidth;
                }

                if (isEditVisible != null)
                {
                    profileProperty.IsEditVisible = (bool)isEditVisible;
                }

                if (isEditReadOnly != null)
                {
                    profileProperty.IsEditReadOnly = (bool)isEditReadOnly;
                }

                if (isEditRequired != null)
                {
                    profileProperty.IsEditRequired = (bool)isEditRequired;
                }

                if (!string.IsNullOrEmpty(editCSS))
                {
                    profileProperty.EditCSS = editCSS;
                }
            }
        }

        #endregion Methods

        #region Methods Edit

        public string EditCSSFor(string propertyName)
        {
            string result = "form-group z-group";

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result += " " + profileProperty.EditCSS;
            }

            return result;
        }

        public string EditCSSGroupFor(string propertyName)
        {
            string result = "form-group z-group";

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result += " " + profileProperty.EditCSS;
            }

            return result;
        }

        public string EditCSSEditorFor(string propertyName)
        {
            string result = "form-control input-sm";

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                if (profileProperty.IsRequiredView || profileProperty.IsEditRequired)
                {
                    result += " z-editorRequired";
                }
                else
                {
                    result += " z-editor";
                }
            }

            return result;
        }

        public string EditCSSEditorDateFor(string propertyName)
        {
            string result = "";

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                if (profileProperty.IsRequiredView || profileProperty.IsEditRequired)
                {
                    result = "z-editorDateRequired";
                }
                else
                {
                    result = "z-editorDate";
                }
            }

            return result;
        }

        public string EditCSSEditorDateTimeFor(string propertyName)
        {
            string result = "";

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                if (profileProperty.IsRequiredView || profileProperty.IsEditRequired)
                {
                    result = "z-editorDateTimeRequired";
                }
                else
                {
                    result = "z-editorDateTime";
                }
            }

            return result;
        }

        public string EditCSSLabelFor(string propertyName)
        {
            string result = "control-label";

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                if (profileProperty.IsRequiredView || profileProperty.IsEditRequired)
                {
                    result += " z-labelRequired";
                }
                else
                {
                    result += " z-label";
                }
            }

            return result;
        }

        public string EditCSSLookupEditor(bool required)
        {
            string result = "form-control input-sm";

            if (required)
            {
                result += "  z-lookupEditorRequired";
            }
            else
            {
                result += "  z-lookupEditorLookup";
            }

            return result;
        }

        public bool IsCollectionVisibleFor(string collectionName)
        {
            bool result = false;

            try
            {
                if (Collections.ContainsKey(collectionName))
                {
                    result = Collections[collectionName];
                }
            }
            catch { }

            return result;
        }

        #endregion Methods Edit

        #region Methods Grid

        public bool IsGridVisibleFor(string propertyName)
        {
            bool result = false;

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result = profileProperty.IsGridVisible;
            }

            return result;
        }

        public int GridWidthFor(string propertyName)
        {
            int result = 100;

            IZProfileProperty profileProperty = GetProfileProperty(propertyName);
            if (profileProperty != null)
            {
                result = profileProperty.GridWidth;
            }

            return result;
        }

        #endregion Methods Grid
    }
}