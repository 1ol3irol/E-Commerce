using Bibliothek.Core.Map;
using Bibliothek.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek.MAP.Option
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(x => x.Name).HasMaxLength(70).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.Quantity).IsRequired();
            Property(x => x.UnitsInStock).IsRequired();
            Property(x => x.ImagePath).IsRequired();
            Property(x => x.Author).HasMaxLength(50).IsOptional();
            Property(x => x.Description).IsOptional();
            Property(x => x.Artist).HasMaxLength(30).IsOptional();
            Property(x => x.Director).HasMaxLength(30).IsOptional();
            Property(x => x.Star).HasMaxLength(100).IsOptional();
            Property(x => x.TradeMark).HasMaxLength(30).IsOptional();

            HasRequired(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.OrderDetails)
               .WithRequired(x => x.Product)
               .HasForeignKey(x => x.ProductID)
               .WillCascadeOnDelete(false);
        }
    }
}
