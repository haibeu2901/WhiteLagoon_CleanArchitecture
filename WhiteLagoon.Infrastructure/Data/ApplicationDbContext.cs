using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // Configure entity properties and relationships here if needed

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = Guid.NewGuid(),
                    Name = "Royal Villa",
                    Description = "A luxurious villa with stunning sea views.",
                    Price = 500.0,
                    Sqft = 550,
                    Occupancy = 4,
                    ImageUrl = "https://example.com/images/royal-villa.jpg",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Villa
                {
                    Id = Guid.NewGuid(),
                    Name = "Premium Pool Villa",
                    Description = "A premium villa with a private pool and garden.",
                    Price = 400.0,
                    Sqft = 500,
                    Occupancy = 4,
                    ImageUrl = "https://example.com/images/premium-pool-villa.jpg",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Villa
                {
                    Id = Guid.NewGuid(),
                    Name = "Normal Pool Villa",
                    Description = "A mornal villa with a no pool and a small garden.",
                    Price = 200.0,
                    Sqft = 250,
                    Occupancy = 4,
                    ImageUrl = "https://example.com/images/normal-garden-villa.jpg",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                });
        }
    }
}
