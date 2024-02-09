using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Core.Contracts.DataContracts
{
    public class WorkplaceUpdateRequestDC
    {
        /// <summary>
        /// Идентификатор связанной комнаты
        /// </summary>
        public int? RoomId { get; set; }

        private string _name;
        /// <summary>
        /// Наименование рабочего места
        /// </summary>
        public string? Name
        {
            get => _name;
            set => _name = Utils.Utils.ReplaceEmptyWithNull(value);
        }

        private string _description;
        /// <summary>
        /// Описание рабочего места
        /// </summary>
        public string? Description
        {
            get => _description;
            set => _description = Utils.Utils.ReplaceEmptyWithNull(value);
        }
    }
}
