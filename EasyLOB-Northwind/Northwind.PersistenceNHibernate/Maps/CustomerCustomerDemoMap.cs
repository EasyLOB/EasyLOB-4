using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class CustomerCustomerDemoMap : ClassMap<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoMap()
        {
            #region Class

            Table("CustomerCustomerDemo");

            CompositeId()
                .KeyProperty(x => x.CustomerId, "CustomerID")
                .KeyProperty(x => x.CustomerTypeId, "CustomerTypeID");

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties

            #endregion Properties

            #region Associations (FK)
                        
            References(x => x.CustomerDemographic)
                .Column("CustomerTypeID");
                        
            References(x => x.Customer)
                .Column("CustomerID");

        #endregion Associations (FK)
        }
    }
}
