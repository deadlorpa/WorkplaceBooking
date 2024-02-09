using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room> GetById(int id);
        Task<int> Create(Room room);
        Task<int> Delete(int id);
        Task<int> Update(Room room);

        Task<IEnumerable<Room>> GetByName(string name);
    }
}
