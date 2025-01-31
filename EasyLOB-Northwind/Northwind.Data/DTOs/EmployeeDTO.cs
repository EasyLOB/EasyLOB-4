using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class EmployeeDTO : ZDTOModel<EmployeeDTO, Employee>
    {
        #region Properties
               
        public virtual int EmployeeId { get; set; }
               
        public virtual string LastName { get; set; }
               
        public virtual string FirstName { get; set; }
               
        public virtual string Title { get; set; }
               
        public virtual string TitleOfCourtesy { get; set; }
               
        public virtual DateTime? BirthDate { get; set; }
               
        public virtual DateTime? HireDate { get; set; }
               
        public virtual string Address { get; set; }
               
        public virtual string City { get; set; }
               
        public virtual string Region { get; set; }
               
        public virtual string PostalCode { get; set; }
               
        public virtual string Country { get; set; }
               
        public virtual string HomePhone { get; set; }
               
        public virtual string Extension { get; set; }
               
        public virtual byte[] Photo { get; set; }
               
        public virtual string Notes { get; set; }
               
        public virtual int? ReportsTo { get; set; }
               
        public virtual string PhotoPath { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeXLookupText { get; set; } // ReportsTo

        #endregion Associations (FK)

        #region Methods

        public EmployeeDTO()
        {
            OnConstructor();
        }

        public EmployeeDTO(IZDataModel dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
