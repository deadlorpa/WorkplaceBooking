using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Interfaces
{
    // TODO: more methods?
    public interface IWorkplaceRepository
    {
        Task<IEnumerable<Workplace>> GetAll();
        Task<IEnumerable<Workplace>> GetByRoomId(int roomId);
        Task<Workplace> GetById(int id);
        Task<Workplace> Create(Workplace workplace);
        Task Delete(int id);
        Task Update(Workplace workplace);
    }
}
