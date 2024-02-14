using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.Domain.Entities;

namespace OnionArch.Persistence.Configuraitons
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x=> new {x.ProductId, x.CategoryId});
            builder.HasOne(p=>p.Product)
                .WithMany(pc=>pc.ProductCategories)
                .HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Category)
            .WithMany(pc => pc.ProductCategories)
            .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
