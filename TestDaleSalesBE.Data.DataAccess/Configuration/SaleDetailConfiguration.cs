using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Data.DataAccess.Configuration
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> entity)
        {
            entity.ToTable("SaleDetail");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SaleDetai__Produ__33D4B598");

            entity.HasOne(d => d.Sale)
                .WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SaleDetai__SaleI__32E0915F");
        }
    }
}