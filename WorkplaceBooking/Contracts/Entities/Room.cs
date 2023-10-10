﻿namespace WorkplaceBooking.Contracts.Entities
{
    public class Room
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
        /// Рабочие места в комнате
        /// </summary>
        public IEnumerable<Workplace> Workplaces { get; set; }
    }
}
