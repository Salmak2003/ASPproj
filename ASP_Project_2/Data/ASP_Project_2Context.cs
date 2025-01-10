using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPproj.Models;

namespace ASP_Project_2.Data
{
    public class ASP_Project_2Context : DbContext
    {
        public ASP_Project_2Context (DbContextOptions<ASP_Project_2Context> options)
            : base(options)
        {
        }

        public DbSet<ASPproj.Models.Item> Item { get; set; } = default!;
        public DbSet<ASPproj.Models.Cart> Cart { get; set; } = default!;
        public DbSet<ASPproj.Models.Customer> Customer { get; set; } = default!;
        public DbSet<ASPproj.Models.Order> Order { get; set; } = default!;
    }
}
