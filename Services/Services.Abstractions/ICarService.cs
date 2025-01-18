using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.Models.Car.SearchCars;

namespace Services.Abstractions
{
    public interface ICarService
    {
        Task<List<SearchCarsResultModel>> SearchCarsAsync(SearchCarsQueryModel queryModel);
    }
}