using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task Create(User user);
        Task Delete(int id);
        Task Update(User user);
    }
}
