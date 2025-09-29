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

        public DbSet<VillaRoom> VillaRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // Configure entity properties and relationships here if needed

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    VillaId = 1,
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
                    VillaId = 2,
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
                    VillaId = 3,
                    Name = "Normal Pool Villa",
                    Description = "A mornal villa with a no pool and a small garden.",
                    Price = 200.0,
                    Sqft = 250,
                    Occupancy = 4,
                    ImageUrl = "https://example.com/images/normal-garden-villa.jpg",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                });

            modelBuilder.Entity<VillaRoom>().HasData(
                new VillaRoom
                {
                    VillaNo = 101,
                    VillaId = 1
                },
                new VillaRoom
                {
                    VillaNo = 102,
                    VillaId = 1
                },
                new VillaRoom
                {
                    VillaNo = 103,
                    VillaId = 1
                },
                new VillaRoom
                {
                    VillaNo = 104,
                    VillaId = 1
                },
                new VillaRoom
                {
                    VillaNo = 201,
                    VillaId = 2
                },
                new VillaRoom
                {
                    VillaNo = 202,
                    VillaId = 2
                },
                new VillaRoom
                {
                    VillaNo = 203,
                    VillaId = 2
                },
                new VillaRoom
                {
                    VillaNo = 301,
                    VillaId = 3
                },
                new VillaRoom
                {
                    VillaNo = 302,
                    VillaId = 3
                });
        }
    }
}
