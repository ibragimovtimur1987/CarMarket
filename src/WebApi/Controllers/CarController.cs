using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Models.Car.Search;
using WebApi.Models.Car.Search;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController: ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly IReservationService _reservationService;
        
        public CarController(ICarService carService, IMapper mapper, IReservationService reservationService)
        {
            _carService = carService;
            _mapper = mapper;
            _reservationService = reservationService;
        }
        
        [HttpPost("search")]
        public async Task<ActionResult<List<SearchCarsResponseModel>>> SearchAsync(SearchCarsRequestModel request, CancellationToken token)
        {
            var query = _mapper.Map<SearchCarsQueryModel>(request);
            var result = await _carService.SearchAsync(query, token);
            var response = _mapper.Map<List<SearchCarsResponseModel>>(result);
            return response;
        }
        
        [HttpPost("{carId:int}/reservation")]
        public async Task<ActionResult> ReservationAsync(int carId, CancellationToken cancellationToken)
        {
            await _reservationService.ReservationAsync(carId, cancellationToken);
            return Ok();
        }
    }
}