using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class TerritoryDTO : ZDTOModel<TerritoryDTO, Territory>
    {
        #region Properties
               
        public virtual string TerritoryId { get; set; }
               
        public virtual string TerritoryDescription { get; set; }
               
        public virtual int RegionId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string RegionLookupText { get; set; } // RegionId

        #endregion Associations (FK)

        #region Methods

        public TerritoryDTO()
        {
            OnConstructor();
        }

        public TerritoryDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
