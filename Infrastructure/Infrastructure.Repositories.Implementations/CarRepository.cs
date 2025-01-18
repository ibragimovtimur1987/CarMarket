using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.Models.Car.Search;

namespace Infrastructure.Repositories.Implementations
{

    public class CarRepository: ICarRepository
    {
        private readonly DatabaseContext _context;
        public CarRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<List<SearchCarsResultModel>> SearchAsync(SearchCarsQueryModel queryModel)
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
                    Price = car.CarPrices.Select(p => p.Price).First()
                })
                .ToListAsync();
        }
    }
}
