using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Interfaces
{
    // TODO: more methods?
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll();
        Task<IEnumerable<Room>> GetByName(string name);
        Task<Room> GetById(int id);
        Task Create(Room room);
        Task Delete(int id);
        Task Update(Room room);
    }
}
