using AutoFixture;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Services.UnitTests.Infrastructure.EntityFramework;

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
        optionsBuilder.UseInMemoryDatabase(_databaseName);
        base.OnConfiguring(optionsBuilder);
    }
}