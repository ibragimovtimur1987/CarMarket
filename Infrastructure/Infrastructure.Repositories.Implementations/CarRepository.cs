using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.Models.Car.GetCars;

namespace Infrastructure.Repositories.Implementations
{

    public class CarRepository: ICarRepository
    {
        private readonly DatabaseContext _context;
        public CarRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<List<GetCarsResultModel>> GetCarsAsync(GetCarsQueryModel queryModel)
        {
            return await _context.Cars
                .Where(car => car.Reservations
                    .All(booking => booking.EndDateUtc < queryModel.AvailabilityDateUtc || booking.StartDateUtc > queryModel.AvailabilityDateUtc))
                .Select(car => new GetCarsResultModel
                {
                    CarId = car.Id
                })
                .ToListAsync();
        }
    }
}
