using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using Services.Contracts.Models.ReservationCar;

namespace Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(
            IMapper mapper,
            IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }
        
        public async Task ReservationAsync(ReservationCarQueryModel query, CancellationToken cancellationToken)
        {
            await _reservationRepository.ReservationAsync(query, cancellationToken);
        }
    }
}