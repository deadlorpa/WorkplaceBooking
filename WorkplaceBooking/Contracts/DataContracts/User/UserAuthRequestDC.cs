using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class UserAuthRequestDC
    {
        /// <summary>
        /// Почтовый адрес пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
