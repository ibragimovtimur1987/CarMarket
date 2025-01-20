using AutoFixture;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace UnitTests.Infrastructure.EntityFramework;

public sealed class TestCarMarketDbContext : DbContext, ICarMarketContext
{
    private readonly IFixture _fixture;

    private readonly string _databaseName;

    public TestCarMarketDbContext()
        : this(null)
    {
    }

    public TestCarMarketDbContext(string databaseName)
    {
        _fixture = new Fixture();
        _databaseName = databaseName ?? _fixture.Create<string>();
        base.Database.EnsureCreated();
        Seed();
    }

    public override void Dispose()
    {
        base.Database.EnsureDeleted();
        base.Dispose();
    }

    public DbSet<Car> Car { get; set; }
        
    public DbSet<CarModel> CarModel { get; set; }
        
    public DbSet<CarBrand> CarBrand { get; set; }
        
    public DbSet<CarPrice> CarPrice { get; set; }
        
    public DbSet<CarReservation> CarReservation { get; set; }
    
    public IServiceProvider ServiceProvider { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(_databaseName).ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        base.OnConfiguring(optionsBuilder);
    }
    
     private void Seed()
    {
        var brands = new List<CarBrand>
        {
            new CarBrand { Name = "Toyota" },
            new CarBrand { Name = "Ford" },
            new CarBrand { Name = "BMW" }
        };

        CarBrand.AddRange(brands);
        SaveChanges();

        var models = new List<CarModel>
        {
            new CarModel { BrandId = brands[0].Id, Name = "Camry" },
            new CarModel { BrandId = brands[0].Id, Name = "Corolla" },
            new CarModel { BrandId = brands[1].Id, Name = "Mustang" },
            new CarModel { BrandId = brands[2].Id, Name = "X5" }
        };

        CarModel.AddRange(models);
        SaveChanges();

        var cars = new List<Car>
        {
            new Car { ModelId = models[0].Id },
            new Car { ModelId = models[1].Id },
            new Car { ModelId = models[2].Id },
            new Car { ModelId = models[3].Id }
        };

        Car.AddRange(cars);

        SaveChanges();

        var priceHistories = new List<CarPrice>
        {
            new CarPrice
            {
                CarId = cars[0].Id, Price = 30000, StartDateUtc = DateTime.Now.AddDays(-10),
                EndDateUtc = DateTime.Now.AddDays(10)
            },
            new CarPrice
            {
                CarId = cars[1].Id, Price = 20000, StartDateUtc = DateTime.Now.AddDays(-5),
                EndDateUtc = DateTime.Now.AddDays(15)
            },
            new CarPrice
            {
                CarId = cars[2].Id, Price = 50000, StartDateUtc = DateTime.Now.AddDays(-20),
                EndDateUtc = DateTime.Now.AddDays(5)
            },
            new CarPrice { CarId = cars[3].Id, Price = 70000, StartDateUtc = DateTime.Now.AddDays(-30) }
        };

        CarPrice.AddRange(priceHistories);
        SaveChanges();

        var reservations = new List<CarReservation>
        {
            new CarReservation
            {
                CarId = cars[0].Id, StartDateUtc = DateTime.UtcNow, EndDateUtc = DateTime.Now.AddDays(10),
                ReservedAtUtc = DateTime.UtcNow
            },
            new CarReservation
            {
                CarId = cars[1].Id, StartDateUtc = DateTime.UtcNow.AddDays(20), EndDateUtc = DateTime.Now.AddDays(30),
                ReservedAtUtc = DateTime.UtcNow.AddDays(10)
            }
        };

        CarReservation.AddRange(reservations);
        SaveChanges();
    }
}