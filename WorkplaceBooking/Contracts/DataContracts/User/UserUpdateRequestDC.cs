using System.ComponentModel.DataAnnotations;
using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class UserUpdateRequestDC
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Почтовый адрес пользователя
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }

        private string _password;
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [MinLength(8)]
        public string Password 
        {
            get => _password; 
            set => _password = Utils.Utils.ReplaceEmptyWithNull(value);
        }

        private string _confirmPassword;
        /// <summary>
        /// Подтверждение пароля пользователя
        /// </summary>
        [Required]
        [Compare("Password")]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => _confirmPassword = Utils.Utils.ReplaceEmptyWithNull(value);
        }
    }
}
