using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.EntityFramework.Configurations;

public sealed class TestDbrainDbContext : DbContext
{
    private readonly IFixture _fixture;

    private readonly string _databaseName;

    public TestDbrainDbContext()
        : this(null)
    {
    }

    public TestDbrainDbContext(string databaseName)
    {
        _fixture = new Fixture();
        _databaseName = databaseName ?? _fixture.Create<string>();
        Database.EnsureCreated();
    }

    public override void Dispose()
    {
        Database.EnsureDeleted();
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarBrandConfiguration).Assembly);
    }
}