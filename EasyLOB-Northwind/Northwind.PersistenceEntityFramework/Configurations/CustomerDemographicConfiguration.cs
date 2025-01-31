using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class CustomerDemographicConfiguration : EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicConfiguration()
        {
            #region Class
            
            this.ToTable("CustomerDemographics");            

            this.HasKey(x => x.CustomerTypeId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.CustomerTypeId)
                .HasColumnName("CustomerTypeID")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
        
            this.Property(x => x.CustomerDesc)
                .HasColumnName("CustomerDesc")
                .HasColumnType("ntext");

            #endregion Properties
        }
    }
}
