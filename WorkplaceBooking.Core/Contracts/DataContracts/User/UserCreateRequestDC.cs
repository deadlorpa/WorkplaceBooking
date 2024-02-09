using System.ComponentModel.DataAnnotations;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Contracts.DataContracts
{
    public class UserCreateRequestDC
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public string LastName { get; set; }

        /// <summary>
        /// Почтовый адрес пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        [EmailAddress(ErrorMessage = "{0} is not email type")]
        public string Email { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        [EnumDataType(typeof(Role), ErrorMessage = "{0} invalid")]
        public Role Role { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        [MinLength(8, ErrorMessage = "{0} must contains more than 8 characters")]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        [Compare("Password", ErrorMessage = "{0} is not equal to {1}")]
        public string ConfirmPassword { get; set; }
    }
}
