namespace WorkplaceBooking.Contracts.DataContracts
{
    public class RoomUpdateRequestDC
    {
        private string _name;
        /// <summary>
        /// Имя комнаты
        /// </summary>
        public string? Name
        {
            get => _name;
            set => _name = Utils.Utils.ReplaceEmptyWithNull(value);
        }
    }
}
