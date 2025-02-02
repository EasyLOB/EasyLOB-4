using System;

namespace EasyLOB.Mvc
{
    public abstract partial class CollectionModel
    {
        #region Properties
            
        public virtual ZOperationResult OperationResult { get; set; }

        public virtual ZActivityOperations ActivityOperations { get; set; }

        public virtual string Entity { get; set; }

        public virtual string ControllerAction { get; set; }

        public virtual string MasterControllerAction { get; set; }

        public virtual string MasterEntity { get; set; }

        public virtual string MasterKey { get; set; }

        public virtual string Operation { get; set; }

        public virtual string OperationAction
        {
            get
            {
                switch ((Operation ?? "").ToLower())
                {
                    case "create":
                        return "Create";
                    default:
                        return "Search";
                }
            }
        }

        public virtual bool IsMasterDetail
        {
            get { return !string.IsNullOrEmpty(MasterEntity) || !string.IsNullOrEmpty(MasterKey); }
        }

        public virtual string Suffix { get; set; }

        public virtual string Id
        {
            get { return Entity + Suffix; }
        }

        #endregion Properties

        #region Methods

        public CollectionModel()
        {
            OperationResult = new ZOperationResult();
            Entity = "";
            Suffix = "";
        }

        public virtual void OnConstructor()
        {
        }

        #endregion Methods
    }
}
