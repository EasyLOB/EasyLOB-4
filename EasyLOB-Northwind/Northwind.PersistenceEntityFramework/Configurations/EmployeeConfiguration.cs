using Northwind.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Northwind.Persistence
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            #region Class
            
            this.ToTable("Employees");            

            this.HasKey(x => x.EmployeeId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
        
            this.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
        
            this.Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar")
                .HasMaxLength(30);
        
            this.Property(x => x.TitleOfCourtesy)
                .HasColumnName("TitleOfCourtesy")
                .HasColumnType("varchar")
                .HasMaxLength(25);
        
            this.Property(x => x.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("datetime");
        
            this.Property(x => x.HireDate)
                .HasColumnName("HireDate")
                .HasColumnType("datetime");
        
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
        
            this.Property(x => x.HomePhone)
                .HasColumnName("HomePhone")
                .HasColumnType("varchar")
                .HasMaxLength(24);
        
            this.Property(x => x.Extension)
                .HasColumnName("Extension")
                .HasColumnType("varchar")
                .HasMaxLength(4);
        
            this.Property(x => x.Photo)
                .HasColumnName("Photo")
                .HasColumnType("image");
        
            this.Property(x => x.Notes)
                .HasColumnName("Notes")
                .HasColumnType("ntext");
        
            this.Property(x => x.ReportsTo)
                .HasColumnName("ReportsTo")
                .HasColumnType("int");
        
            this.Property(x => x.PhotoPath)
                .HasColumnName("PhotoPath")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            #endregion Properties

            #region Associations (FK)

            this.HasOptional(x => x.EmployeeX)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ReportsTo);

            #endregion Associations (FK)
        }
    }
}
