using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Concurrent;


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
        await Task.Delay(-1); 
    }

    static ConcurrentDictionary<long, bool> userStates = new ConcurrentDictionary<long, bool>();

    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message?.Text != null)
        {
            long chatId = update.Message.Chat.Id;
            string userMessage = update.Message.Text;

            if (userMessage == "Повернутися до головного меню" || userMessage == "/start")
            {
                userStates[chatId] = false;

                await botClient.SendTextMessageAsync(chatId,
                    "Вітаємо! Це служба підтримки hive.report (ФОП Глоба О.В.).\r\n" +
                    "Щоб продовжити далі та зв’язатися з нами або отримати інформацію, натисніть\r\n" +
                    "кнопку👇\r\nМи цінуємо нашу співпрацю❤",
                    replyMarkup: MainButtons()
                );
            }
            else if (userStates.ContainsKey(chatId) && userStates[chatId])
            {
                return;
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId,
                    "Бот не може обробити таке повідомлення. Якщо у вас є питання, зверніться до менеджера.",
                    replyMarkup: ErrorMessageButton()
                );
            }
        }
        else if (update.CallbackQuery != null)
        {
            await HandleCallbackQuery(botClient, update.CallbackQuery);
        }
    }

 
    static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        long chatId = callbackQuery.Message.Chat.Id;
        string action = callbackQuery.Data;

        switch (action)
        {
            case "contact_team":
                userStates[chatId] = true; await botClient.SendTextMessageAsync(chatId, "Зараз менеджер приєднається до Вас! Поки опишіть ситуацію. Дякую 📥", replyMarkup: BackToMain());
                break;


            case "get_info":
                await botClient.SendTextMessageAsync(chatId, "Оберіть категорію:", replyMarkup: GetMoreInfo());
                break;

            case "digital_signature":
                await botClient.SendTextMessageAsync(chatId, "Кваліфікований електронний підпис\r\nМає таку ж юридичну силу, як і власноручний підпис, та має презумпцію його\r\nвідповідності власноручному підпису (П.4 ст. 18 ЗУ №2155-VII від 5.10.2017 р.).\r\nМи формуємо та обслуговуємо електронні підпис від ЦСК “Україна”. Його можна\r\nвикористовувати на всіх державних порталах та в наших продуктів.\r\nЯкщо не маєте КЕП, пропонуємо завітати до нас в офіс за записом або замовити\r\nвиїзд спеціаліста для формування.",
                    replyMarkup: DigitalSignatureButtons());
                break;
            case "list_of_documents_QES":
                await botClient.SendTextMessageAsync(chatId, "Формування підпису відбувається при особистій присутності підписанта з\r\nнеобхідним пакетом документів. Перелік документів можете знайти нижче.",
                    replyMarkup: ListOfDocumentsForQES());
                break;
            case "me_doc":
                await botClient.SendTextMessageAsync(chatId, "M.E.Doc – найкраще рішення для електронного документообігу.", replyMarkup: BackToMain());
                break;

            case "cashalot":
                await botClient.SendTextMessageAsync(chatId, "Cashalot – сучасна альтернатива касовим апаратам.", replyMarkup: BackToMain());
                break;

            case "sota":
                await botClient.SendTextMessageAsync(chatId, "СОТА – веб-сервіс для подачі звітності онлайн.", replyMarkup: BackToMain());
                break;


            case "about_us":
                await botClient.SendTextMessageAsync(chatId, "Ми допомагаємо бізнесу в електронному документообігу!", replyMarkup: BackToMain());
                break;
            case "contacts":
                await botClient.SendTextMessageAsync(chatId, "Наш сайт: https://hive.report/ \nТелефон: +38 (063) 247 66 99", replyMarkup: BackToMain());
                break;

        }
    }

    static InlineKeyboardMarkup MainButtons()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Зв’язатися з командою", "contact_team") },
            new [] { InlineKeyboardButton.WithCallbackData("Отримати довідкову інформацію", "get_info") },
            new [] { InlineKeyboardButton.WithCallbackData("Про нас", "about_us"), InlineKeyboardButton.WithCallbackData("Контакти", "contacts") }
        });
    }

    static InlineKeyboardMarkup ErrorMessageButton()
    {
        return new InlineKeyboardMarkup(
            InlineKeyboardButton.WithCallbackData("Зв’язатися з менеджером", "contact_team")
        );
    }

    static InlineKeyboardMarkup GetMoreInfo()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Електронний підпис", "digital_signature") },
            new [] { InlineKeyboardButton.WithCallbackData("M.E.Doc", "me_doc") },
            new [] { InlineKeyboardButton.WithCallbackData("Cashalot", "cashalot") },
            new [] { InlineKeyboardButton.WithCallbackData("СОТА", "sota") },
        });
    }

    static InlineKeyboardMarkup DigitalSignatureButtons()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Перелік документів для отримання КЕП", "list_of_documents_QES") },
            new [] { InlineKeyboardButton.WithCallbackData("Як подавати підпис онлайн", "how_to_apply_online") },
            new [] { InlineKeyboardButton.WithCallbackData("Як зареєструвати КЕП в ДПС", "how_to_registrate_QES") },
            new [] { InlineKeyboardButton.WithCallbackData("Термінологія", "termins") },
        });
    }



    static InlineKeyboardMarkup ListOfDocumentsForQES()
    {
        return new InlineKeyboardMarkup(new[]
        {
        new []
        {
            InlineKeyboardButton.WithUrl("Для юридичних осіб",
                "https://uakey.com.ua/files/uploads/86fef5c0d65b30a81c346a67a0fa1deb.pdf")
        },
        new []
        {
            InlineKeyboardButton.WithUrl("Для фізичних осіб",
                "https://uakey.com.ua/files/uploads/a28af51d52c44abd882f4e76bdcf0f57.pdf")
        },
    });
    }

    static ReplyKeyboardMarkup BackToMain()
    {
        return new ReplyKeyboardMarkup(new[]
        {
        new KeyboardButton[] { "Повернутися до головного меню" },
    })
        {
            ResizeKeyboard = true
        };
    }

    static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Error occurred: {exception.Message}");
        return Task.CompletedTask;
    }
}
