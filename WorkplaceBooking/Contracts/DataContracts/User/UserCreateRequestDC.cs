using System.ComponentModel.DataAnnotations;
using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class UserCreateRequestDC
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Почтовый адрес пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        [Required]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля пользователя
        /// </summary>
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
