using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Contracts.DataContracts.Extensions
{
    public static class RoomExtensions
    {
        /// <summary>
        /// Возвращает RoomFullResponceDC, сформированный из Room и списка Workplace
        /// </summary>
        /// <param name="room"></param>
        /// <param name="workplaces"></param>
        /// <returns></returns>
        public static RoomFullResponceDC ToRoomFullResponce(Room room, IEnumerable<Workplace> workplaces)
        {
            return new RoomFullResponceDC()
            {
                Id = room.Id,
                Name = room.Name,
                Workplaces = workplaces
            };
        }
    }
}
