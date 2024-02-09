using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IJwtUtils
    {
        /// <summary>
        /// Генерация токена пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateJwtToken(User user);

        /// <summary>
        /// Валидация токена
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int? ValidateJwtToken(string? token);
    }
}
