using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IReservationService
    {
        Task ReservationAsync(int carId, CancellationToken cancellationToken);
    }
}