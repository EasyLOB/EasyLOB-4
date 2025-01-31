using Northwind.Data;
using FluentNHibernate.Mapping;

namespace Northwind.Persistence
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            #region Class

            Table("Categories");

            Id(x => x.CategoryId)
                .Column("CategoryID")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.CategoryName)
                .Column("CategoryName")
                .CustomSqlType("varchar")
                .Length(15)
                .Not.Nullable();
            
            Map(x => x.Description)
                .Column("Description")
                .CustomSqlType("varchar")
                .Length(1024);
            
            Map(x => x.Picture)
                .Column("Picture")
                .CustomSqlType("varbinary");

            #endregion Properties
            
            #region Collections (PK)

            HasMany(x => x.Products)
                .KeyColumn("CategoryId");

            #endregion Collections (PK)
        }
    }
}
