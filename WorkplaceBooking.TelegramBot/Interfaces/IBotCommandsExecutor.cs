using Telegram.Bot.Types;

namespace WorkplaceBooking.TelegramBot.Interfaces
{
    /// <summary>
    /// Исполнитель команд
    /// </summary>
    public interface IBotCommandsExecutor
    {
        /// <summary>
        /// Исполнить требуемую команду
        /// </summary>
        /// <param name="command"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task Execute(string command, Update update);
    }
}
