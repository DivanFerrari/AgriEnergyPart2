using FarmerAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FarmerAPI.Models
{
    public class FarmDbContext : DbContext
    {
        public DbSet<Farmer> Farmers { get; set; }

        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farmer>()
                .Property(c => c.Name)
                .HasPrecision(5, 2);
        }
    }
}