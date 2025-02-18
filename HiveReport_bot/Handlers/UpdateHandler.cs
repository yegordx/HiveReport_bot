using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Telegram.Bot.TelegramBotClient;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace HiveReport_bot.Handlers;

public class UpdateHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly MessageHandler _messageHandler;
    private readonly CallbackHandler _callbackHandler;

    public UpdateHandler(ITelegramBotClient botClient, MessageHandler messageHandler, CallbackHandler callbackHandler)
    {
        _botClient = botClient;
        _messageHandler = messageHandler;
        _callbackHandler = callbackHandler;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message != null)
        {
            await _messageHandler.HandleMessageAsync(botClient, update.Message);
        }
        else if (update.CallbackQuery != null)
        {
            await _callbackHandler.HandleCallbackAsync(botClient, update.CallbackQuery);
        }
    }

    public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Ошибка: {exception.Message}");
    }
}
