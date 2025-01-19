using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.Models.Car.Search;

namespace Services.Repositories.Abstractions
{
    public interface ICarRepository
    {
        Task<List<SearchCarsResultModel>> SearchAsync(SearchCarsQueryModel queryModel, CancellationToken cancellationToken);
    }
}
