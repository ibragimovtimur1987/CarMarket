using AutoMapper;
using Services.Contracts.Models.Car.GetCars;
using WebApi.Models.Car.GetCars;

namespace WebApi.Mapping
{
    public class CarMappingsProfile : Profile
    {
        public CarMappingsProfile()
        {
            CreateMap<GetCarsQueryModel, GetCarsRequestModel>();
            CreateMap<GetCarsResultModel, GetCarsResponseModel>();
        }
    }
}
