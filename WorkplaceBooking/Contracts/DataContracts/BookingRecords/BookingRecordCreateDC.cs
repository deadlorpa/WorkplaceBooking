using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class BookingRecordCreateDC
    {
        /// <summary>
        /// Идентификатор пользователя-холдера бронирования
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор рабочего места
        /// </summary>
        [Required]
        public int WorkplaceId { get; set; }

        /// <summary>
        /// Дата и время старта бронирования
        /// </summary>
        [Required]
        public DateTime StartBookingDateTime { get; set; }

        /// <summary>
        /// Дата и время окончания бронирования
        /// </summary>
        [Required]
        public DateTime EndBookingDateTime { get; set; }
    }
}
