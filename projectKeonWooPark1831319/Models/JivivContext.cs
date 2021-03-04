using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace projectKeonWooPark1831319.Models
{
    public class JivivContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> Models { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}