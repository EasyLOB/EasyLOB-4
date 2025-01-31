using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityDTO : ZDTOModel<ActivityDTO, Activity>
    {
        #region Properties
               
        public virtual string Id { get; set; }
               
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods

        public ActivityDTO()
        {
            OnConstructor();
        }

        public ActivityDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
