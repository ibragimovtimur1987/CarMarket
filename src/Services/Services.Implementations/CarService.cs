using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using Services.Contracts.Models.Car.Search;

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
        public async Task<List<SearchCarsResultModel>> SearchAsync(SearchCarsQueryModel queryModel, CancellationToken cancellationToken)
        {
            return await _carRepository.SearchAsync(queryModel, cancellationToken);
        }
    }
}