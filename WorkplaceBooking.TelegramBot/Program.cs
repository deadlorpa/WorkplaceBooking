using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using WorkplaceBooking.TelegramBot.BotCommands;
using WorkplaceBooking.TelegramBot.Entities;
using WorkplaceBooking.TelegramBot.Interfaces;
using WorkplaceBooking.TelegramBot.Services;
using WorkplaceBooking.TelegramBot.Extensions;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.Configure<BotConfiguration>(context.Configuration.GetSection("BotConfiguration"));
    services.AddHttpClient("WorkplaceBooking_tg_bot").AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
    {
        BotConfiguration? botConfiguration = sp.GetConfiguration<BotConfiguration>();
        TelegramBotClientOptions botClientOptions = new TelegramBotClientOptions(botConfiguration.Token);
        return new TelegramBotClient(botClientOptions, httpClient);
    });
    services.AddSingleton<ReceiverOptions>(options =>
    {
        return new ReceiverOptions()
        {
            AllowedUpdates = Array.Empty<UpdateType>(),
            ThrowPendingUpdates = true
        };
    });
    services.AddScoped<IBotCommandsExecutor, BotCommandsExecutor>();
    services.AddScoped<IUpdateHandler, UpdateHandlerService>();
    services.AddScoped<IReceiverService, RecieverService>();
    services.AddHostedService<PoolingService>();
});

var host = builder.Build();

await host.RunAsync();