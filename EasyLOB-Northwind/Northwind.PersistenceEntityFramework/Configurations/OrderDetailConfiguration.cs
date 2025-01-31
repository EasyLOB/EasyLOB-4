using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {
            #region Class
            
            this.ToTable("Order Details");            

            this.HasKey(x => new { x.OrderId , x.ProductId });

            #endregion Class

            #region Properties
        
            this.Property(x => x.OrderId)
                .HasColumnName("OrderID")
                .HasColumnOrder(1)
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
        
            this.Property(x => x.ProductId)
                .HasColumnName("ProductID")
                .HasColumnOrder(2)
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
        
            this.Property(x => x.UnitPrice)
                .HasColumnName("UnitPrice")
                .HasColumnType("money")
                .IsRequired();
        
            this.Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("smallint")
                .IsRequired();
        
            this.Property(x => x.Discount)
                .HasColumnName("Discount")
                .HasColumnType("real")
                .IsRequired();

            #endregion Properties

            #region Associations (FK)
            
            this.HasRequired(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);
            
            this.HasRequired(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);
        
            #endregion Associations (FK)
        }
    }
}
