using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Repositories.Abstractions;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DatabaseContext _context;
        private readonly int ReservationDaysCount = 10;
        public ReservationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task ReservationAsync(int carId, CancellationToken cancellationToken)
        {
            if (!await _context.Car.AnyAsync(c => c.Id == carId, cancellationToken))
            {
                throw new Exception($"Car with id {carId} does not exist");
            }

            var isReserv = _context.CarReservation.Any(cr => cr.CarId == carId &&
                                                             cr.StartDateUtc <= DateTime.UtcNow.AddDays(ReservationDaysCount) &&
                                                             DateTime.UtcNow <= cr.EndDateUtc);
            if (isReserv)
            {
                throw new Exception("Car is already reserved");
            }

            var newReserv = new CarReservation
            {
                CarId = carId,
                StartDateUtc = DateTime.UtcNow,
                EndDateUtc = DateTime.UtcNow.AddDays(ReservationDaysCount),
                ReservedAtUtc = DateTime.UtcNow
            };

            _context.CarReservation.Add(newReserv);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

