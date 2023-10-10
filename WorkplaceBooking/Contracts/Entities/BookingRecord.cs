namespace WorkplaceBooking.Contracts.Entities
{
    public class BookingRecord
    {
        /// <summary>
        /// Идентификатор записи о бронировании
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя-холдера бронирования
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Признак отмены бронирования
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// Дата и время старта бронирования
        /// </summary>
        public DateTime StartBookingDateTime { get; set; }

        /// <summary>
        /// Дата и время окончания бронирования
        /// </summary>
        public DateTime EndBookingDateTime { get; set; }
    }
}
