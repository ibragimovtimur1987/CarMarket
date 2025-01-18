using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.Models.Car.GetCars;
using WebApi.Models.Car.GetCars;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController: ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ILogger<CarController> _logger;
        private readonly IReservationService _reservationService;
        
        public CarController(ICarService carService, ILogger<CarController> logger, IMapper mapper, IReservationService reservationService)
        {
            _carService = carService;
            _logger = logger;
            _mapper = mapper;
            _reservationService = reservationService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetCarsAsync(GetCarsRequestModel request)
        {
            var query = _mapper.Map<GetCarsQueryModel>(request);
            var result = await _carService.GetCarsAsync(query);
            var response = _mapper.Map<GetCarsResponseModel>(result);
            return Ok(response);
        }
        
        [HttpPost("{carId:int}/reservation")]
        public async Task<IActionResult> ReservationAsync(int carId, CancellationToken cancellationToken)
        {
            await _reservationService.ReservationAsync(carId, cancellationToken);
            return Ok();
        }
    }
}