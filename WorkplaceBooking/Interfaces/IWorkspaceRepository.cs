using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Interfaces
{
    // TODO: more methods?
    public interface IWorkspaceRepository
    {
        Task<IEnumerable<Workplace>> GetAll();
        Task<Workplace> GetById(int id);
        Task Create(Workplace workplace);
        Task Delete(int id);
        Task Update(Workplace workplace);
    }
}
