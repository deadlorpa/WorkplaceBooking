using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using WorkplaceBooking.TelegramBot.Interfaces;

namespace WorkplaceBooking.TelegramBot.Services
{
    public class UpdateHandlerService : IUpdateHandler
    {
        private readonly IBotCommandsExecutor _botCommandsExecutor;
        private readonly ILogger<UpdateHandlerService> _logger;

        public UpdateHandlerService(IBotCommandsExecutor botCommandsExecutor, ILogger<UpdateHandlerService> logger) 
        {
            _botCommandsExecutor = botCommandsExecutor;
            _logger = logger;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient _, Update update, CancellationToken cancellationToken)
        {
            var handler = update switch
            {
                { Message: { } message } => MessageTypeHandler(update, cancellationToken),
                { EditedMessage: { } message } => MessageTypeHandler(update, cancellationToken),
                // TODO: implement
                { CallbackQuery: { } callbackQuery } => UnknownTypeHandler(update, cancellationToken),
                { InlineQuery: { } inlineQuery } => UnknownTypeHandler(update, cancellationToken),
                { ChosenInlineResult: { } chosenInlineResult } => UnknownTypeHandler(update, cancellationToken),
                // ---------------
                _ => UnknownTypeHandler(update, cancellationToken)
            };
            await handler;
        }

        private async Task MessageTypeHandler(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Receive message type: {MessageType}", update.Message?.Type);
            // TODO: kakoe-to govno - need DTO
            var action = update.Message.Text.Split(' ')[0];
            await _botCommandsExecutor.Execute(action, update);
        }

        private Task UnknownTypeHandler(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
            return Task.CompletedTask;
        }

        public async Task HandlePollingErrorAsync(ITelegramBotClient _, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogInformation("HandleError: {ErrorMessage}", ErrorMessage);

            if (exception is RequestException)
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }
    }
}
