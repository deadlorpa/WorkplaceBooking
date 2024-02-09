using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Core.Contracts.Extensions
{
    /// <summary>
    /// Расширение BookingRecord
    /// </summary>
    public static class BookingRecordExtensions
    {
        /// <summary>
        /// Проверка наличия конфликта диапазонов бронирования у двух записей
        /// </summary>
        /// <param name=""></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public static bool HasDateConflict(this BookingRecord record, BookingRecord anotherRecord)
        {
            return 
                !(record.EndBookingDateTime <= anotherRecord.StartBookingDateTime 
                || record.StartBookingDateTime >= anotherRecord.EndBookingDateTime);
        }
    }
}
