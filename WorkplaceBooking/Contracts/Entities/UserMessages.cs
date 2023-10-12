﻿namespace WorkplaceBooking.Contracts.Entities
{
    // TODO: переработать - вынести в файл локали en и ру и от них билдить сообщения
    public static class UserMessages
    {
        public static string UserCreated = "Пользователь создан";
        public static string UserUpdated = "Пользователь обновлен";
        public static string UserDeleted = "Пользователь удален";
        public static string UserNotFound = "Пользователь не найден";
        public static string UserEmailExist = "Данный email уже привязан к другому пользователю";
        public static string IncorrectPassword = "Неверный пароль";
    }
}
