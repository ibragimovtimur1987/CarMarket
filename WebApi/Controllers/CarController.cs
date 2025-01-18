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
    [Route("[controller]")]
    public class CarController: ControllerBase
    {
        private readonly ICarService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CarController> _logger;

        public CarController(ICarService service, ILogger<CarController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> GetCarsAsync(GetCarsRequestModel request)
        {
            var query = _mapper.Map<GetCarsQueryModel>(request);
            var result = await _service.GetCarsAsync(query);
            var response = _mapper.Map<GetCarsResponseModel>(result);
            return Ok(response);
        }
    }
}