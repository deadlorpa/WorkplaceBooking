using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class RoomFullResponceDC
    {
        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя комнаты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Рабочие места
        /// </summary>
        public IEnumerable<Workplace> Workplaces { get; set; }
    }
}
