using Telegram.Bot;
using Telegram.Bot.Types;
using WorkplaceBooking.TelegramBot.Interfaces;

namespace WorkplaceBooking.TelegramBot.BotCommands
{
    internal class StartBotCommand : IBotCommand
    {
        public string Name
        {
            get
            {
                return "/start";
            }
        }

        public async Task Execute(ITelegramBotClient botClient, Update update)
        {
            var answer = "yo";
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, answer);
        }
    }
}
