using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class RoomCreateRequestDC
    {
        /// <summary>
        /// Имя комнаты
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
