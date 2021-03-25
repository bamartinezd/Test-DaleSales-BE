using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Data.DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.UnitValue).HasColumnType("money");
        }
    }
}