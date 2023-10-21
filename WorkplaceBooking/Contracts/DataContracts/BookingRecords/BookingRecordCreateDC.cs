using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class BookingRecordCreateDC
    {
        /// <summary>
        /// Идентификатор пользователя-холдера бронирования
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор рабочего места
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public int WorkplaceId { get; set; }

        /// <summary>
        /// Дата и время старта бронирования
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public DateTime StartBookingDateTime { get; set; }

        /// <summary>
        /// Дата и время окончания бронирования
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public DateTime EndBookingDateTime { get; set; }
    }
}
