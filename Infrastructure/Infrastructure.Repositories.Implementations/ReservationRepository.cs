using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Repositories.Abstractions;
using Infrastructure.EntityFramework;

namespace Infrastructure.Repositories.Implementations
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly DatabaseContext _context;
        public ReservationRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task ReservationAsync(int carId, CancellationToken cancellationToken)
        {
            var isReserv = _context.CarReservations.Any(cr => cr.CarId == carId && 
                                                              cr.StartDateUtc <= DateTime.UtcNow.AddDays(10) &&
                                                              DateTime.UtcNow <= cr.EndDateUtc);
            if (isReserv)
            {
                throw new Exception("Car is already reserved");
            }
          
            var newReserv = new CarReservation
            {
                CarId = carId,
                StartDateUtc = DateTime.UtcNow,
                EndDateUtc = DateTime.UtcNow.AddDays(10),
                ReservedAtUtc = DateTime.UtcNow
            };

            _context.CarReservations.Add(newReserv);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
