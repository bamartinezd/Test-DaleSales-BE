using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestDaleSalesBE.Data.DataAccess.Configuration;
using TestDaleSalesBE.Domain.Entities;

#nullable disable

namespace TestDaleSalesBE.Data.DataAccess
{
    public partial class Test_Dale_SalesContext : DbContext
    {
        public Test_Dale_SalesContext()
        {
        }

        public Test_Dale_SalesContext(DbContextOptions<Test_Dale_SalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new SaleDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
