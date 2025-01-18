using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.Models.Car.GetCars;

namespace Services.Abstractions
{
    public interface ICarService
    {
        Task<List<GetCarsResultModel>> GetCarsAsync(GetCarsQueryModel queryModel);
    }
}