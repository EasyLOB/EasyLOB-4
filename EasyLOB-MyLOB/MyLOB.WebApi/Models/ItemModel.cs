using System;

namespace EasyLOB.Mvc
{
    public abstract partial class ItemModel
    {
        #region Properties
        
        public virtual ZOperationResult OperationResult { get; set; }

        public virtual ZActivityOperations ActivityOperations { get; set; }

        public virtual string Entity { get; set; }

        public virtual string ControllerAction { get; set; }

        public virtual string MasterEntity { get; set; }

        public virtual string MasterKey { get; set; }

        public virtual bool IsMasterDetail
        {
            get { return !string.IsNullOrEmpty(MasterEntity) || !string.IsNullOrEmpty(MasterKey); }
        }

        public bool IsReadOnly { get; set; }

        private bool _isSave = false;

        public bool IsSave
        {
            get { return _isSave; }
            set
            {
                _isSave = IsMasterDetail ? false : value;
            }
        }

        public virtual string Suffix { get; set; }

        public virtual string Id
        {
            get { return Entity + Suffix; }
        }

        #endregion Properties

        #region Methods

        public ItemModel()
        {
            OperationResult = new ZOperationResult();
            Entity = "";
            IsReadOnly = false;
            IsSave = false;
            Suffix = "";
        }

        public virtual void OnConstructor()
        {
        }

        #endregion Methods
    }
}
