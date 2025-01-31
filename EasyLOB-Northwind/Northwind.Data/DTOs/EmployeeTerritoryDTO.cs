using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class EmployeeTerritoryDTO : ZDTOModel<EmployeeTerritoryDTO, EmployeeTerritory>
    {
        #region Properties
               
        public virtual int EmployeeId { get; set; }
               
        public virtual string TerritoryId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string TerritoryLookupText { get; set; } // TerritoryId

        #endregion Associations (FK)

        #region Methods

        public EmployeeTerritoryDTO()
        {
            OnConstructor();
        }

        public EmployeeTerritoryDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
