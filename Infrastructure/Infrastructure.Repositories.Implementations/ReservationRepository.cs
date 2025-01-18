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
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(10);

            var newBooking = new CarReservation
            {
                CarId = carId,
                StartDateUtc = startDate,
                EndDateUtc = endDate
            };

            _context.CarReservations.Add(newBooking);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
