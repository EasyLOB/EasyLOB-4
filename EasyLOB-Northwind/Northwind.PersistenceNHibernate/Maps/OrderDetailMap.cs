using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class OrderDetailMap : ClassMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            #region Class

            Table("Order Details");

            CompositeId()
                .KeyProperty(x => x.OrderId, "OrderID")
                .KeyProperty(x => x.ProductId, "ProductID");

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.UnitPrice)
                .Column("UnitPrice")
                .CustomSqlType("money")
                .Not.Nullable();
            
            Map(x => x.Quantity)
                .Column("Quantity")
                .CustomSqlType("smallint")
                .Not.Nullable();
            
            Map(x => x.Discount)
                .Column("Discount")
                .CustomSqlType("real")
                .Not.Nullable();

            #endregion Properties

            #region Associations (FK)
                        
            References(x => x.Order)
                .Column("OrderID");
                        
            References(x => x.Product)
                .Column("ProductID");

        #endregion Associations (FK)
        }
    }
}
