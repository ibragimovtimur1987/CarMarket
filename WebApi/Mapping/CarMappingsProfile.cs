using AutoMapper;
using Services.Contracts.Models.Car.SearchCars;
using WebApi.Models.Car.SearchCars;

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
