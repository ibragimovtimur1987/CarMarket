using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.Models.ReservationCar;

namespace Services.Repositories.Abstractions
{
    public interface IReservationRepository
    {
        Task ReservationAsync(ReservationCarQueryModel model, CancellationToken cancellationToken);
    }
}
