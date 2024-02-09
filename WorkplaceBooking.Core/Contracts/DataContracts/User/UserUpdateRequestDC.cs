using System.ComponentModel.DataAnnotations;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Contracts.DataContracts
{
    public class UserUpdateRequestDC
    {
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
        [EmailAddress(ErrorMessage = "{0} is not email type")]
        public string? Email { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        [EnumDataType(typeof(Role), ErrorMessage = "{0} invalid")]
        public Role? Role { get; set; }

        private string _password;
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [MinLength(8, ErrorMessage = "{0} must contains more than 8 characters")]
        public string? Password 
        {
            get => _password; 
            set => _password = Utils.Utils.ReplaceEmptyWithNull(value);
        }

        private string _confirmPassword;
        /// <summary>
        /// Подтверждение пароля пользователя
        /// </summary>
        [Compare("Password", ErrorMessage = "{0} is not equal to {1}")]
        public string? ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = Utils.Utils.ReplaceEmptyWithNull(value);
        }
    }
}
