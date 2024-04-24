using WorkplaceBooking.Core.Dal.Repositories;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDatabaseContext _dataContext;
        private IUserRepository _userRepository;
        private IBookingRepository _bookingRepository;
        private IRoomRepository _roomRepository;
        private IWorkplaceRepository _workplaceRepository;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _dataContext = databaseContext;
        }

        public IUserRepository UserRepository 
        {
            get 
            {
                return _userRepository ?? (_userRepository = new UserRepository(_dataContext));
            }
        }

        public IBookingRepository BookingRepository
        {
            get 
            {
                return _bookingRepository ?? (_bookingRepository = new BookingRepository(_dataContext)); 
            }
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                return _roomRepository ?? (_roomRepository = new RoomRepository(_dataContext));
            }
        }

        public IWorkplaceRepository WorkplaceRepository
        {
            get
            {
                return _workplaceRepository ?? (_workplaceRepository = new WorkplaceRepository(_dataContext));
            }
        }
    }
}
