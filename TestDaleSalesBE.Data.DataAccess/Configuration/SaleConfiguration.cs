using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestDaleSalesBE.Domain.Entities;

namespace TestDaleSalesBE.Data.DataAccess.Configuration
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entity)
        {
            entity.ToTable("Sale");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");

            entity.Property(e => e.SaleDate).HasColumnType("datetime");

            entity.Property(e => e.TotalValue).HasColumnType("money");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Sale__ClientID__286302EC");
        }
    }
}