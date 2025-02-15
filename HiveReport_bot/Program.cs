using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    static async Task Main(string[] args)
    {
        var botClient = new TelegramBotClient("7675831655:AAEKgcV6b6FeVdPFEOWcnK44_-FkwhFxBQ0");

        using var cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>(),
            DropPendingUpdates = true
        };

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandleErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        Console.WriteLine("Bot is running. Press any key to exit...");
        await Task.Delay(-1); // Keep the bot running indefinitely
    }

    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message?.Text != null)
        {
            long chatId = update.Message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, "Вітаємо! Це служба підтримки hive.report. Виберіть дію:",
                replyMarkup: MainButtons());
        }
        else if (update.CallbackQuery != null)
        {
            await HandleCallbackQuery(botClient, update.CallbackQuery);
        }
    }

    static InlineKeyboardMarkup MainButtons()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new []
            {
                InlineKeyboardButton.WithCallbackData("Зв’язатися з командою", "contact_team"),
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData("Отримати довідкову інформацію", "get_info"),
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData("Про нас", "about_us"),
                InlineKeyboardButton.WithCallbackData("Контакти", "contacts"),
            }
        });
    }

    static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        long chatId = callbackQuery.Message.Chat.Id;
        string action = callbackQuery.Data;
        
        if (action == "contact_team")
        {
            await botClient.SendTextMessageAsync(chatId, "Зараз менеджер приєднається до Вас! Поки опишіть ситуацію. Дякую 📥");
        }
        else if (action == "get_info")
        {
            await botClient.SendTextMessageAsync(chatId, "Оберіть категорію:", replyMarkup: GetInfoButtons());
        }
        else if (action == "about_us")
        {
            await botClient.SendTextMessageAsync(chatId, "Ми допомагаємо бізнесу в електронному документообігу!", replyMarkup: BackToMainButton());
        }
        else if (action == "contacts")
        {
            await botClient.SendTextMessageAsync(chatId, "Наш сайт: https://hive.report/ \nТелефон: +38 (063) 247 66 99", replyMarkup: BackToMainButton());
        }
    }

    static InlineKeyboardMarkup GetInfoButtons()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Електронний підпис", "digital_signature") },
            new [] { InlineKeyboardButton.WithCallbackData("M.E.Doc", "me_doc") },
            new [] { InlineKeyboardButton.WithCallbackData("Cashalot", "cashalot") },
            new [] { InlineKeyboardButton.WithCallbackData("СОТА", "sota") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "back") }
        });
    }

    static InlineKeyboardMarkup BackToMainButton()
    {
        return new InlineKeyboardMarkup(
            InlineKeyboardButton.WithCallbackData("Назад до головного меню", "back")
        );
    }

    static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Error occurred: {exception.Message}");
        return Task.CompletedTask;
    }
}
