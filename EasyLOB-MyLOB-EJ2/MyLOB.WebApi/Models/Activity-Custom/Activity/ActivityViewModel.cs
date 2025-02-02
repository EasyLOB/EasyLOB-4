using System;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityViewModel
    {        
        #region Methods
        
        public override void OnConstructor()
        {
            Id = Guid.NewGuid().ToString();
        }

        #endregion Methods
    }
}
