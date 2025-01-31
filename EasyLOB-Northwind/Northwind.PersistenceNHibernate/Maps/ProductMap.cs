using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            #region Class

            Table("Products");

            Id(x => x.ProductId)
                .Column("ProductID")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.ProductName)
                .Column("ProductName")
                .CustomSqlType("varchar")
                .Length(40)
                .Not.Nullable();
            
            Map(x => x.SupplierId)
                .Column("SupplierID")
                .CustomSqlType("int");
            
            Map(x => x.CategoryId)
                .Column("CategoryID")
                .CustomSqlType("int");
            
            Map(x => x.QuantityPerUnit)
                .Column("QuantityPerUnit")
                .CustomSqlType("varchar")
                .Length(20);
            
            Map(x => x.UnitPrice)
                .Column("UnitPrice")
                .CustomSqlType("money");
            
            Map(x => x.UnitsInStock)
                .Column("UnitsInStock")
                .CustomSqlType("smallint");
            
            Map(x => x.UnitsOnOrder)
                .Column("UnitsOnOrder")
                .CustomSqlType("smallint");
            
            Map(x => x.ReorderLevel)
                .Column("ReorderLevel")
                .CustomSqlType("smallint");
            
            Map(x => x.Discontinued)
                .Column("Discontinued")
                .CustomSqlType("bit")
                .Not.Nullable();

            #endregion Properties

            #region Associations (FK)
                        
            References(x => x.Category)
                .Column("CategoryID");
                        
            References(x => x.Supplier)
                .Column("SupplierID");

        #endregion Associations (FK)
            
            #region Collections (PK)

            HasMany(x => x.OrderDetails)
                .KeyColumn("ProductId");

            #endregion Collections (PK)
        }
    }
}
