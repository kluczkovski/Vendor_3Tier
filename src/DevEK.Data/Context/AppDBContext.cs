using System;
using DevEK.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevEK.Data.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) :base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // get all classes that have implmented the IEntityTypeConfiguration interface
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);

            //  
            base.OnModelCreating(modelBuilder);
        }
    }
}
