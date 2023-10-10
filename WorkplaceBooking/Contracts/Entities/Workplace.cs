﻿namespace WorkplaceBooking.Contracts.Entities
{
    public class Workplace
    {
        /// <summary>
        /// Идентификатор рабочего места
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование рабочего места
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание рабочего места
        /// </summary>
        public string Description { get; set; }
    }
}
