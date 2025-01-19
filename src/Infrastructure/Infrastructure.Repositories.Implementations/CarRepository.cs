using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.Models.Car.Search;

namespace Infrastructure.Repositories.Implementations
{

    public class CarRepository: ICarRepository
    {
        private readonly ICarMarketContext _context;
        public CarRepository(ICarMarketContext context)
        {
            _context = context;
        }
        
        public async Task<List<SearchCarsResultModel>> SearchAsync(SearchCarsQueryModel queryModel, CancellationToken cancellationToken)
        {
            return await _context.Car
                .Where(car => car.Reservations
                    .All(res => res.StartDateUtc > queryModel.AvailabilityDateUtc || 
                                res.EndDateUtc < queryModel.AvailabilityDateUtc))
                .Where(car => car.CarPrices
                    .Any(p => queryModel.AvailabilityDateUtc > p.StartDateUtc && 
                              (p.EndDateUtc == null || queryModel.AvailabilityDateUtc < p.EndDateUtc)))
                .Select(car => new SearchCarsResultModel
                {
                    CarId = car.Id,
                    Price = car.CarPrices.Select(p => p.Price).First(),
                    Brand = car.Model.CarBrand.Name,
                    Model = car.Model.Name,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
