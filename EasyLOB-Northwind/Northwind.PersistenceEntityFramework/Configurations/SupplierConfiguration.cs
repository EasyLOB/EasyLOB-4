using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            #region Class
            
            this.ToTable("Suppliers");            

            this.HasKey(x => x.SupplierId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.SupplierId)
                .HasColumnName("SupplierID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        
            this.Property(x => x.ContactName)
                .HasColumnName("ContactName")
                .HasColumnType("varchar")
                .HasMaxLength(30);
        
            this.Property(x => x.ContactTitle)
                .HasColumnName("ContactTitle")
                .HasColumnType("varchar")
                .HasMaxLength(30);
        
            this.Property(x => x.Address)
                .HasColumnName("Address")
                .HasColumnType("varchar")
                .HasMaxLength(60);
        
            this.Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .HasMaxLength(15);
        
            this.Property(x => x.Region)
                .HasColumnName("Region")
                .HasColumnType("varchar")
                .HasMaxLength(15);
        
            this.Property(x => x.PostalCode)
                .HasColumnName("PostalCode")
                .HasColumnType("varchar")
                .HasMaxLength(10);
        
            this.Property(x => x.Country)
                .HasColumnName("Country")
                .HasColumnType("varchar")
                .HasMaxLength(15);
        
            this.Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar")
                .HasMaxLength(24);
        
            this.Property(x => x.Fax)
                .HasColumnName("Fax")
                .HasColumnType("varchar")
                .HasMaxLength(24);

            this.Property(x => x.HomePage)
                .HasColumnName("HomePage")
                .HasColumnType("ntext");

            #endregion Properties
        }
    }
}
