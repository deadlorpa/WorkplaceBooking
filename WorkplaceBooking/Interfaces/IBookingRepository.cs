using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingRecord>> GetAll();
        Task<IEnumerable<BookingRecord>> GetByUserId(int userId);
        Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId);
        Task<BookingRecord> GetById(int id);
        Task Create(BookingRecord record);
        Task Delete(int id);
        Task Update(BookingRecord record);
    }
}
