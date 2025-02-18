using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveReport_bot.Handlers;

namespace HiveReport_bot.Services;

using HiveReport_bot.Handlers;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

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

        // Удаляем Webhook перед Long Polling
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
