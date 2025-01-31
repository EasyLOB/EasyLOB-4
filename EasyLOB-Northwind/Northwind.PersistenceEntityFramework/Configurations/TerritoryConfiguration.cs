using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class TerritoryConfiguration : EntityTypeConfiguration<Territory>
    {
        public TerritoryConfiguration()
        {
            #region Class
            
            this.ToTable("Territories");            

            this.HasKey(x => x.TerritoryId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.TerritoryId)
                .HasColumnName("TerritoryID")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
        
            this.Property(x => x.TerritoryDescription)
                .HasColumnName("TerritoryDescription")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        
            this.Property(x => x.RegionId)
                .HasColumnName("RegionID")
                .HasColumnType("int")
                .IsRequired();

            #endregion Properties

            #region Associations (FK)
            
            this.HasRequired(x => x.Region)
                .WithMany(x => x.Territories)
                .HasForeignKey(x => x.RegionId);
        
            #endregion Associations (FK)
        }
    }
}
