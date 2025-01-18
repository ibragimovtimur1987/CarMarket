using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.Models.ReservationCar;

namespace Services.Abstractions
{
    public interface IReservationService
    {
        Task ReservationAsync(ReservationCarQueryModel query, CancellationToken cancellationToken);
    }
}