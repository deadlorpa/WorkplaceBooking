using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IUserRepository : IRepository <User>
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<int> Create(User user);
        Task<int> Delete(int id);
        Task<int> Update(User user);

        Task<User> GetByEmail(string email);
    }
}
