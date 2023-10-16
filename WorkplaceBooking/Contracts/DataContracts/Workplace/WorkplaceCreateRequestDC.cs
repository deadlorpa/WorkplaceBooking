using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class WorkplaceCreateRequestDC
    {
        /// <summary>
        /// Идентификатор связанной комнаты
        /// </summary>
        [Required]
        public int RoomId { get; set; }

        /// <summary>
        /// Наименование рабочего места
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание рабочего места
        /// </summary>
        public string? Description { get; set; }
    }
}
