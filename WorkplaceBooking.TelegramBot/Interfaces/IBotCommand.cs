using Telegram.Bot;
using Telegram.Bot.Types;

namespace WorkplaceBooking.TelegramBot.Interfaces
{
    /// <summary>
    /// Команды бота
    /// </summary>
    public interface IBotCommand
    { 
        /// <summary>
        /// Имя команды
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Исполнить действие
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        Task Execute(ITelegramBotClient botClient, Update update);
    }
}
