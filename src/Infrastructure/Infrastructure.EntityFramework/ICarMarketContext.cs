using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.EntityFramework;

public interface ICarMarketContext
{
    public DbSet<Car> Car { get; set; }
        
    public DbSet<CarModel> CarModel { get; set; }
        
    public DbSet<CarBrand> CarBrand { get; set; }
        
    public DbSet<CarPrice> CarPrice { get; set; }
        
    public DbSet<CarReservation> CarReservation { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    DatabaseFacade Database { get; }
}