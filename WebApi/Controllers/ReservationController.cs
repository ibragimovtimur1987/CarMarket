using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.Models.ReservationCar;
using WebApi.Models.Reservation.Reservation;
using WebApi.Models.Reservation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController: ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationController> _logger;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger, IMapper mapper)
        {
            _reservationService = reservationService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> ReservationAsync(ReservationCarRequestModel requestModel, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<ReservationCarQueryModel>(requestModel);
             await _reservationService.ReservationAsync(query, cancellationToken);
            return Ok();
        }
    }
}