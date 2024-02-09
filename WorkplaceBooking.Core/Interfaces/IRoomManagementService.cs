using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Interfaces
{
    public interface IRoomManagementService
    {
        /// <summary>
        /// Возвращает список всех комнат с вложенными рабочими пространствами
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RoomFullResponceDC>> GetFull();

        /// <summary>
        /// Возвращает список всех комнат
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Room>> GetAllRooms();

        /// <summary>
        /// Возвращает рабочие места по id комнаты
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task<IEnumerable<Workplace>> GetWorkplacesByRoomId(int roomId);

        /// <summary>
        /// Создать рабочее пространство
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Workplace> CreateWorkplace(WorkplaceCreateRequestDC request);

        /// <summary>
        /// Создать комнату
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Room> CreateRoom(RoomCreateRequestDC request);

        /// <summary>
        /// Обновить рабочее место
        /// </summary>
        /// <param name="idWorkplace"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Workplace> UpdateWorkplace(int idWorkplace, WorkplaceUpdateRequestDC request);

        /// <summary>
        /// Обновить комнату
        /// </summary>
        /// <param name="idRoom"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Room> UpdateRoom(int idRoom, RoomUpdateRequestDC request);

        /// <summary>
        /// Удалить комнату
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        Task DeleteRoom(int roomId);

        /// <summary>
        /// Удалить рабочее место
        /// </summary>
        /// <param name="idWorkplace"></param>
        /// <returns></returns>
        Task DeleteWorkplace(int idWorkplace);
    }
}
