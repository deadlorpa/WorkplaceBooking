using WorkplaceBooking.TelegramBot.Interfaces;

namespace WorkplaceBooking.TelegramBot.Services
{
    public class PoolingService : BackgroundService
    {
        private readonly IReceiverService _receiverService;
        private readonly ILogger<PoolingService> _logger;
        public PoolingService(IReceiverService receiverService, ILogger<PoolingService> logger)
        {
            _receiverService = receiverService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting pooling service");
            await Run(cancellationToken);
        }

        private async Task Run(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await _receiverService.ReceiveAsync(cancellationToken);
                }
                catch
                (Exception ex)
                {
                    _logger.LogError("Polling failed with exception: {Exception}", ex);
                }
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }
    }
}
