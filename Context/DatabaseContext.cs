using CartCar.App.Context.Config;
using CartCar.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartCar.App.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Cartcar> cartcars { get; set; }
        public DbSet<DrivingOffenses> drivingOffenses { get; set; }
        public DbSet<InfractionCar> infractionCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartcarConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
