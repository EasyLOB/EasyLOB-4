using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class ShipperConfiguration : EntityTypeConfiguration<Shipper>
    {
        public ShipperConfiguration()
        {
            #region Class
            
            this.ToTable("Shippers");            

            this.HasKey(x => x.ShipperId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.ShipperId)
                .HasColumnName("ShipperID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        
            this.Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar")
                .HasMaxLength(24);

            #endregion Properties
        }
    }
}
