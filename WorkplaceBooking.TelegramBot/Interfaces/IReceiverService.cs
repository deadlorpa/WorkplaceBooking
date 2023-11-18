namespace WorkplaceBooking.TelegramBot.Interfaces
{
    /// <summary>
    /// Сервис получения обновлений из Телеграм API
    /// </summary>
    public interface IReceiverService
    {
        /// <summary>
        /// Получить обновление
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ReceiveAsync(CancellationToken cancellationToken);
    }
}
