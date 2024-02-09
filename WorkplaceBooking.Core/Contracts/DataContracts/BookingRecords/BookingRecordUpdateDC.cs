using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class BookingRecordUpdateDC
    {
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
