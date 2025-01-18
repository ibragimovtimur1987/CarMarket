using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<CarModel> CarModels { get; set; }
        
        public DbSet<Brand> Brands { get; set; }
        
        public DbSet<Price> Prices { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            
            modelBuilder.Entity<Car>()
                .HasMany(u => u.Reservations)
                .WithOne(c=> c.Car)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);   
        }
    }
}