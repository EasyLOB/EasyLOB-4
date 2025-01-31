using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            #region Class
            
            this.ToTable("Products");            

            this.HasKey(x => x.ProductId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.ProductId)
                .HasColumnName("ProductID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.ProductName)
                .HasColumnName("ProductName")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        
            this.Property(x => x.SupplierId)
                .HasColumnName("SupplierID")
                .HasColumnType("int");
        
            this.Property(x => x.CategoryId)
                .HasColumnName("CategoryID")
                .HasColumnType("int");
        
            this.Property(x => x.QuantityPerUnit)
                .HasColumnName("QuantityPerUnit")
                .HasColumnType("varchar")
                .HasMaxLength(20);
        
            this.Property(x => x.UnitPrice)
                .HasColumnName("UnitPrice")
                .HasColumnType("money");
        
            this.Property(x => x.UnitsInStock)
                .HasColumnName("UnitsInStock")
                .HasColumnType("smallint");
        
            this.Property(x => x.UnitsOnOrder)
                .HasColumnName("UnitsOnOrder")
                .HasColumnType("smallint");
        
            this.Property(x => x.ReorderLevel)
                .HasColumnName("ReorderLevel")
                .HasColumnType("smallint");
        
            this.Property(x => x.Discontinued)
                .HasColumnName("Discontinued")
                .HasColumnType("bit")
                .IsRequired();

            #endregion Properties

            #region Associations (FK)
            
            this.HasOptional(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
            
            this.HasOptional(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierId);
        
            #endregion Associations (FK)
        }
    }
}
