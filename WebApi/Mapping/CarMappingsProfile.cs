using AutoMapper;
using Services.Contracts.Models.Car.GetCars;
using WebApi.Models.Car.GetCars;

namespace WebApi.Mapping
{
    public class CarMappingsProfile : Profile
    {
        public CarMappingsProfile()
        {
            CreateMap<GetCarsRequestModel, GetCarsQueryModel>(MemberList.Destination);
            CreateMap<GetCarsResultModel, GetCarsResponseModel>(MemberList.Destination);
        }
    }
}
