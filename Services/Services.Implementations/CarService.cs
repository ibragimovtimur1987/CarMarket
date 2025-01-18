using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using Services.Contracts.Models.Car.GetCars;

namespace Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CarService(
            IMapper mapper,
            ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }
        public async Task<List<GetCarsResultModel>> GetCarsAsync(GetCarsQueryModel queryModel)
        {
            return await _carRepository.GetCarsAsync(queryModel);
        }
    }
}