using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OG_Sports.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=OGSports") { }
   
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductsPerOrder> ProductsPerOrder { get; set; }
    }
}