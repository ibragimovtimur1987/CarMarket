using System;
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
            var newBooking = new CarReservation
            {
                CarId = carId,
                StartDateUtc = DateTime.UtcNow,
                EndDateUtc = DateTime.UtcNow.AddDays(10),
                ReservedAtUtc = DateTime.UtcNow
            };

            _context.CarReservations.Add(newBooking);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
