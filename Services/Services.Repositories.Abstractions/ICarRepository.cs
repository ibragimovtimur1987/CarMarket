using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.Models.Car.SearchCars;

namespace Services.Repositories.Abstractions
{
    public interface ICarRepository
    {
        Task<List<SearchCarsResultModel>> SearchCarsAsync(SearchCarsQueryModel queryModel);
    }
}
