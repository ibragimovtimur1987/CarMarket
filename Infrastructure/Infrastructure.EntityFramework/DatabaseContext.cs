using System;
using Domain.Entities;
using Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        public DbSet<Car> Car { get; set; }
        
        public DbSet<CarModel> CarModel { get; set; }
        
        public DbSet<CarBrand> CarBrand { get; set; }
        
        public DbSet<CarPrice> CarPrice { get; set; }
        
        public DbSet<CarReservation> CarReservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            
            modelBuilder.Entity<Car>()
                .HasMany(u => u.Reservations)
                .WithOne(c=> c.Car)
                .IsRequired();
            
            modelBuilder.ApplyConfiguration(new CarBrandConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelConfiguration());
            modelBuilder.ApplyConfiguration(new CarPriceConfiguration());
            modelBuilder.ApplyConfiguration(new CarReservationConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);   
        }
    }
}