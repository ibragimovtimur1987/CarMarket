using System.Threading;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    public interface IReservationRepository
    {
        Task ReservationAsync(int carId, CancellationToken cancellationToken);
    }
}
