using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Core.Contracts.DataContracts
{
    public class UserAuthRequestDC
    {
        /// <summary>
        /// Почтовый адрес пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        [EmailAddress(ErrorMessage = "{0} is not email type")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public string Password { get; set; }
    }
}
