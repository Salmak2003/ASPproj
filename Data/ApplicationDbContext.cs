using ASPproj.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPproj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Item> item { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Cart> cart{ get; set; }
        public DbSet<Cart_item> cart_item { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Order_item> order_item { get; set; }

    }
}
