using ASPproj.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPproj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_item> Cart_Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order_item> Order_Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();

            modelBuilder
                .Entity<Item>()
                .HasData(
                    new Item
                    {
                        Id = "1",
                        Name = "Laptop",
                        Price = 1200,
                        StockQuantity = 50,
                    },
                    new Item
                    {
                        Id = "2",
                        Name = "Smartphone",
                        Price = 800,
                        StockQuantity = 150,
                    },
                    new Item
                    {
                        Id = "3",
                        Name = "Headphones",
                        Price = 150,
                        StockQuantity = 200,
                    },
                    new Item
                    {
                        Id = "4",
                        Name = "Monitor",
                        Price = 300,
                        StockQuantity = 80,
                    },
                    new Item
                    {
                        Id = "5",
                        Name = "Keyboard",
                        Price = 70,
                        StockQuantity = 120,
                    }
                );
        }
    }
}
