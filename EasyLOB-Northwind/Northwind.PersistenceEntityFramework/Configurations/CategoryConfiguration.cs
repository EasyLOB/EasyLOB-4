using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            #region Class
            
            this.ToTable("Categories");            

            this.HasKey(x => x.CategoryId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.CategoryId)
                .HasColumnName("CategoryID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.CategoryName)
                .HasColumnName("CategoryName")
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();
        
            this.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("ntext");
        
            this.Property(x => x.Picture)
                .HasColumnName("Picture")
                .HasColumnType("image");

            #endregion Properties
        }
    }
}
