using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            #region Class
            
            this.ToTable("Customers");            

            this.HasKey(x => x.CustomerId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.CustomerId)
                .HasColumnName("CustomerID")
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
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

            #endregion Properties
        }
    }
}
