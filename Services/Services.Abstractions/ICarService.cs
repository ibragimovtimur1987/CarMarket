using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.Models.Car.Search;

namespace Services.Abstractions
{
    public interface ICarService
    {
        Task<List<SearchCarsResultModel>> SearchCarsAsync(SearchCarsQueryModel queryModel);
    }
}