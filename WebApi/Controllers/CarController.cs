using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.Models.Car.SearchCars;
using WebApi.Models.Car.SearchCars;

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
        
        [HttpPost("search")]
        public async Task<IActionResult> SearchCarsAsync(SearchCarsRequestModel request)
        {
            var query = _mapper.Map<SearchCarsQueryModel>(request);
            var result = await _carService.SearchCarsAsync(query);
            var response = _mapper.Map<List<SearchCarsResponseModel>>(result);
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