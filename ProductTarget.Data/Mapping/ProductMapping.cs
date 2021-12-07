using Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Data.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description);
            builder.Property(x => x.ShortDescription);
            builder.Property(x => x.RegisterDate);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Value);
            builder.Property(x => x.Active);
            builder.Property(x => x.CategoryId)
                .IsRequired(false);

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("fk_product_category");
        }
    }
}
