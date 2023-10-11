﻿using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;

namespace WorkplaceBooking.Contracts.DataContracts
{
    public static class UserExtensions
    {
        /// <summary>
        /// Возвращает UserAuthResponceDC, сформированный из User и токена
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static UserAuthResponceDC ToUserAuthResponce(User user, string token)
        {
            return new UserAuthResponceDC()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
        }
    }
}
