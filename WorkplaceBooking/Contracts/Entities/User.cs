namespace WorkplaceBooking.Contracts.Entities
{
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Почтовый адрес пользователя
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public Role? Role { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string? Password { get; set; }
    }
}
