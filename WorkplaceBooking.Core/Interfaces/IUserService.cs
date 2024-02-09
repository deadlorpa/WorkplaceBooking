using WorkplaceBooking.Core.Contracts.DataContracts;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserAuthResponceDC> Auth(UserAuthRequestDC model);

        /// <summary>
        /// Получения списка всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAll();

        /// <summary>
        /// Получение конкретного пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        Task<User> GetById(int id);

        /// <summary>
        /// Получение конкретного пользователя по email
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        Task<User> GetByEmail(string email);

        /// <summary>
        /// Создание пользователя по контракту
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        Task Create(UserCreateRequestDC contract);

        /// <summary>
        /// Обновление пользователя по контракту и id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contract"></param>
        /// <returns></returns>
        Task Update(int id, UserUpdateRequestDC contract);

        /// <summary>
        /// Удаление пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
