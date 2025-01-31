using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class CustomerDemographicMap : ClassMap<CustomerDemographic>
    {
        public CustomerDemographicMap()
        {
            #region Class

            Table("CustomerDemographics");

            Id(x => x.CustomerTypeId)
                .Column("CustomerTypeID")
                .CustomSqlType("varchar")
                .GeneratedBy.Assigned()
                .Length(10)
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.CustomerDesc)
                .Column("CustomerDesc")
                .CustomSqlType("varchar")
                .Length(1024);

            #endregion Properties
            
            #region Collections (PK)

            HasMany(x => x.CustomerCustomerDemos)
                .KeyColumn("CustomerTypeId");

            #endregion Collections (PK)
        }
    }
}
