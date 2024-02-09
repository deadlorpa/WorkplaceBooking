using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class WorkplaceCreateRequestDC
    {
        /// <summary>
        /// Идентификатор связанной комнаты
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public int RoomId { get; set; }

        /// <summary>
        /// Наименование рабочего места
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public string Name { get; set; }

        /// <summary>
        /// Описание рабочего места
        /// </summary>
        public string? Description { get; set; }
    }
}
