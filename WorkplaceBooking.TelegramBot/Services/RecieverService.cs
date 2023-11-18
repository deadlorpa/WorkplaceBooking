using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using WorkplaceBooking.TelegramBot.Interfaces;

namespace WorkplaceBooking.TelegramBot.Services
{
    public class RecieverService : IReceiverService
    {
        private readonly ReceiverOptions _receiverOptions;
        private readonly ITelegramBotClient _botClient;
        private readonly IUpdateHandler _updateHandler;
        private readonly ILogger<RecieverService> _logger;

       public RecieverService(ITelegramBotClient botClient, IUpdateHandler updateHandler, ILogger<RecieverService> logger, ReceiverOptions receiverOptions) 
        {
            _botClient = botClient;
            _updateHandler = updateHandler;
            _logger = logger;
            _receiverOptions = receiverOptions;
        }

        public async Task ReceiveAsync(CancellationToken cancellationToken)
        {
            var me = await _botClient.GetMeAsync(cancellationToken);
            _logger.LogInformation("Start receiving updates for {BotName}", me.Username ?? "WorkplaceBooking Bot");

            await _botClient.ReceiveAsync(
                updateHandler: _updateHandler,
                receiverOptions: _receiverOptions,
                cancellationToken: cancellationToken);
        }
    }
}
