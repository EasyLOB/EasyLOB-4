using System;
using System.Runtime.Serialization;

namespace EasyLOB.Data
{
    [DataContract]
    [Serializable]
    public class ZProfileProperty : IZProfileProperty
    {
        #region Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsKey { get; set; }

        [DataMember]
        public bool IsIdentity { get; set; }

        //[DataMember]
        //public bool IsRequiredData { get; set; }

        [DataMember]
        public bool IsRequiredView
        {
            get { return IsAttributeRequired || IsEditRequired; }
            set { }
        }

        [DataMember]
        public bool IsAttributeRequired { get; set; }

        #endregion Properties

        #region Properties Edit

        [DataMember]
        public bool IsEditVisible { get; set; }

        [DataMember]
        public bool IsEditReadOnly { get; set; }

        [DataMember]
        public bool IsEditRequired { get; set; }

        [DataMember]
        public string EditCSS { get; set; }

        #endregion Properties Edit

        #region Properties Grid

        [DataMember]
        public bool IsGridVisible { get; set; }

        [DataMember]
        public bool IsGridSearch { get; set; }

        [DataMember]
        public int GridWidth { get; set; }

        #endregion Properties Grid

        #region Methods

        public ZProfileProperty()
        {
        }

        #endregion Methods;
    }
}