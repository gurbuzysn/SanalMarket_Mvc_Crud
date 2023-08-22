using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SanalMarket.Data;

namespace SanalMarket.Context
{
    public class SanalMarketDbContext : DbContext
    {
        public SanalMarketDbContext(DbContextOptions<SanalMarketDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Ekmek", Price = 5, StockQuantity = 10, ImageName = "ekmek.jpg"},
                new Product() { Id = 2, Name = "Peynir", Price = 100, StockQuantity = 20, ImageName = "peynir.jpg"},
                new Product() { Id = 3, Name = "Zeytin", Price = 50, StockQuantity = 30, ImageName = "zeytin.jpg"}
                );
        }


    }
}
