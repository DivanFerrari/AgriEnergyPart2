using Microsoft.EntityFrameworkCore;
using ProductAPI.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProductAPI.Models
{
    public class FarmDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(c => c.Category)
                .HasPrecision(5, 2);
        }
    }
}