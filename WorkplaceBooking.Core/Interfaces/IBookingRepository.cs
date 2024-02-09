using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IBookingRepository : IRepository <BookingRecord>
    {
        Task<IEnumerable<BookingRecord>> GetAll();
        Task<BookingRecord> GetById(int id);
        Task<int> Create(BookingRecord record);
        Task<int> Delete(int id);
        Task<int> Update(BookingRecord record);

        Task<IEnumerable<BookingRecord>> GetByUserId(int userId);
        Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId);
        Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId, DateTime date);
    }
}
