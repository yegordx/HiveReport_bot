using HiveReport_bot.Handlers;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace HiveReport_bot.Services;

public class TelegramBotService : IHostedService
{
    private readonly ITelegramBotClient _botClient;
    private readonly UpdateHandler _updateHandler;
    private CancellationTokenSource _cts;

    public TelegramBotService(ITelegramBotClient botClient, UpdateHandler updateHandler)
    {
        _botClient = botClient;
        _updateHandler = updateHandler;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

       await _botClient.DeleteWebhookAsync();

        _botClient.StartReceiving(
            _updateHandler.HandleUpdateAsync,
            _updateHandler.HandleErrorAsync,
            new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() },
            _cts.Token
        );


        Console.WriteLine("Бот запущен!");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _cts.Cancel();
        Console.WriteLine("Бот остановлен.");
        return Task.CompletedTask;
    }
}