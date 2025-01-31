using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class CustomerCustomerDemoConfiguration : EntityTypeConfiguration<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoConfiguration()
        {
            #region Class
            
            this.ToTable("CustomerCustomerDemo");            

            this.HasKey(x => new { x.CustomerId , x.CustomerTypeId });

            #endregion Class

            #region Properties
        
            this.Property(x => x.CustomerId)
                .HasColumnName("CustomerID")
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
        
            this.Property(x => x.CustomerTypeId)
                .HasColumnName("CustomerTypeID")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            #endregion Properties

            #region Associations (FK)
            
            this.HasRequired(x => x.CustomerDemographic)
                .WithMany(x => x.CustomerCustomerDemos)
                .HasForeignKey(x => x.CustomerTypeId);
            
            this.HasRequired(x => x.Customer)
                .WithMany(x => x.CustomerCustomerDemos)
                .HasForeignKey(x => x.CustomerId);
        
            #endregion Associations (FK)
        }
    }
}
