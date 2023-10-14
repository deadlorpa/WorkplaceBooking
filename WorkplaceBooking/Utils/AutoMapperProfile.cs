using AutoMapper;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCreateRequestDC, User>();
            CreateMap<UserUpdateRequestDC, User>();
            CreateMap<BookingRecordCreateDC, BookingRecord>();
            CreateMap<BookingRecordUpdateDC, BookingRecord>();
        }
    }
}
