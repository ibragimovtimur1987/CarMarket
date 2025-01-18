using AutoMapper;
using Services.Contracts.Models.Car.Search;
using WebApi.Models.Car.Search;

namespace WebApi.Mapping
{
    public class CarMappingsProfile : Profile
    {
        public CarMappingsProfile()
        {
            CreateMap<SearchCarsRequestModel, SearchCarsQueryModel>(MemberList.Destination);
            CreateMap<SearchCarsResultModel, SearchCarsResponseModel>(MemberList.Destination);
        }
    }
}
