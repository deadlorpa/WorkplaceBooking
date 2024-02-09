namespace WorkplaceBooking.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBookingRepository BookingRepository { get; }
        IRoomRepository RoomRepository { get; }
        IWorkplaceRepository WorkplaceRepository { get; }
    }
}
