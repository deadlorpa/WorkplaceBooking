using System.Runtime.CompilerServices;
using Telegram.Bot;
using Telegram.Bot.Types;
using WorkplaceBooking.TelegramBot.Interfaces;

namespace WorkplaceBooking.TelegramBot.BotCommands
{
    public class BotCommandsExecutor : IBotCommandsExecutor
    {
        private readonly ITelegramBotClient _botClient;
        // TODO: reflection of commands? IBotCommand got prop Name!
        private readonly Dictionary<string, IBotCommand> _botCommands;
        public BotCommandsExecutor(ITelegramBotClient botClient) 
        {
            _botClient = botClient;
            _botCommands = new Dictionary<string, IBotCommand>
            {
                { "/start", new StartBotCommand() },
                { "/login", new LoginBotCommand() }
            };
        }

        public async Task Execute(string command, Update update)
        {
            if(!_botCommands.ContainsKey(command))
                throw new NotImplementedException();
            await _botCommands[command].Execute(_botClient, update);
        }
    }
}
