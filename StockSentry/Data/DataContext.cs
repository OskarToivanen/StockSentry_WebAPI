using Microsoft.EntityFrameworkCore;
using StockSentry.Models;

namespace StockSentry.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>()
                .HasOne(i => i.Category)
                .WithMany(c => c.InventoryItems)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<InventoryItem>()
                .HasMany(i => i.InventoryLogs)
                .WithOne(l => l.InventoryItem)
                .HasForeignKey(l => l.InventoryItemId);
        }
    }
}
