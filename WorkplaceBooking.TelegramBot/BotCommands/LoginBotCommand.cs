using Telegram.Bot;
using Telegram.Bot.Types;
using WorkplaceBooking.TelegramBot.Interfaces;

namespace WorkplaceBooking.TelegramBot.BotCommands
{
    public class LoginBotCommand : IBotCommand
    {
        public string Name
        {
            get
            {
                return "/login";
            }
        }

        public async Task Execute(ITelegramBotClient botClient, Update update)
        {

            // TODO: kakoe-to govno - need DTO
            var text = update.Message.Text.Split(' ');
            var answer = "Failed";
            if (text.Length > 1)
            {
                var secretWord = text[1];
                var secretWordChecked = secretWord == "DBA";
                answer = secretWordChecked ? "Success" : "Failed";
            }
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, answer);
        }
    }
}
