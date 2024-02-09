using WorkplaceBooking.Core.Contracts.DataContracts;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IBookingService
    {
        /// <summary>
        /// Получение всех записей о бронировании
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookingRecord>> GetAll();

        /// <summary>
        /// Получение всех записей о бронировании по id пользователя
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookingRecord>> GetByUserId(int idUser);

        /// <summary>
        /// Получение всех записей о бронировании по id рабочего места
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId);

        /// <summary>
        /// Получение всех записей о бронировании по id рабочего места в определенную дату
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BookingRecord>> GetByWorkplaceId(int workplaceId, DateTime date);

        /// <summary>
        /// Получение записи о бронировании по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BookingRecord> GetById(int id);

        /// <summary>
        /// Создание записи о бронировании
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task Create(BookingRecordCreateDC contract);

        /// <summary>
        /// Удаление записи о бронировании
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// Изменение записи о бронировании
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task Update(int id, BookingRecordUpdateDC contract);
    }
}
