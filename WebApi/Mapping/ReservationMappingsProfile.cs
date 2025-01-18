using AutoMapper;
using Services.Contracts.Models.ReservationCar;
using WebApi.Models.Reservation.Reservation;

namespace WebApi.Mapping
{
    public class ReservationMappingsProfile : Profile
    {
        public ReservationMappingsProfile()
        {
            CreateMap<ReservationCarRequestModel, ReservationCarQueryModel>();
        }
    }
}
