using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.Models.Car.GetCars;

namespace Services.Repositories.Abstractions
{
    public interface ICarRepository
    {
        Task<List<GetCarsResultModel>> GetCarsAsync(GetCarsQueryModel queryModel);
    }
}
