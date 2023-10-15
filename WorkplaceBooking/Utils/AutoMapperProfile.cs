using AutoMapper;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCreateRequestDC, User>();
            CreateMap<UserUpdateRequestDC, User>()
                .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));
            CreateMap<BookingRecordCreateDC, BookingRecord>();
            CreateMap<BookingRecordUpdateDC, BookingRecord>();
        }
    }
}
