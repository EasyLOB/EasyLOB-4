using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            #region Class
            
            this.ToTable("Orders");            

            this.HasKey(x => x.OrderId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.OrderId)
                .HasColumnName("OrderID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.CustomerId)
                .HasColumnName("CustomerID")
                .HasColumnType("varchar")
                .HasMaxLength(5);
        
            this.Property(x => x.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasColumnType("int");
        
            this.Property(x => x.OrderDate)
                .HasColumnName("OrderDate")
                .HasColumnType("datetime");
        
            this.Property(x => x.RequiredDate)
                .HasColumnName("RequiredDate")
                .HasColumnType("datetime");
        
            this.Property(x => x.ShippedDate)
                .HasColumnName("ShippedDate")
                .HasColumnType("datetime");
        
            this.Property(x => x.ShipVia)
                .HasColumnName("ShipVia")
                .HasColumnType("int");
        
            this.Property(x => x.Freight)
                .HasColumnName("Freight")
                .HasColumnType("money");
        
            this.Property(x => x.ShipName)
                .HasColumnName("ShipName")
                .HasColumnType("varchar")
                .HasMaxLength(40);
        
            this.Property(x => x.ShipAddress)
                .HasColumnName("ShipAddress")
                .HasColumnType("varchar")
                .HasMaxLength(60);
        
            this.Property(x => x.ShipCity)
                .HasColumnName("ShipCity")
                .HasColumnType("varchar")
                .HasMaxLength(15);
        
            this.Property(x => x.ShipRegion)
                .HasColumnName("ShipRegion")
                .HasColumnType("varchar")
                .HasMaxLength(15);
        
            this.Property(x => x.ShipPostalCode)
                .HasColumnName("ShipPostalCode")
                .HasColumnType("varchar")
                .HasMaxLength(10);
        
            this.Property(x => x.ShipCountry)
                .HasColumnName("ShipCountry")
                .HasColumnType("varchar")
                .HasMaxLength(15);

            #endregion Properties

            #region Associations (FK)
            
            this.HasOptional(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);
            
            this.HasOptional(x => x.Employee)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.EmployeeId);
            
            this.HasOptional(x => x.Shipper)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShipVia);
        
            #endregion Associations (FK)
        }
    }
}
