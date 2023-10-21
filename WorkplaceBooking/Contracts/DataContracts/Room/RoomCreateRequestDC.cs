﻿using System.ComponentModel.DataAnnotations;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public class RoomCreateRequestDC
    {
        /// <summary>
        /// Имя комнаты
        /// </summary>
        [Required(ErrorMessage = "{0} is a required field")]
        public string Name { get; set; }
    }
}
