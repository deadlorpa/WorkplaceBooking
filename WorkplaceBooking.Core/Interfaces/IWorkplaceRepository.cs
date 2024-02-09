using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IWorkplaceRepository : IRepository<Workplace>
    {
        Task<IEnumerable<Workplace>> GetAll();
        Task<Workplace> GetById(int id);
        Task<int> Create(Workplace workplace);
        Task<int> Delete(int id);
        Task<int> Update(Workplace workplace);

        Task<IEnumerable<Workplace>> GetByRoomId(int roomId);
    }
}
