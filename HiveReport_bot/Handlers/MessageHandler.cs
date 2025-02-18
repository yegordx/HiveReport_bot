using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using HiveReport_bot.Keyboards;
using Telegram.Bot.Types.ReplyMarkups;
using HiveReport_bot.Services;

namespace HiveReport_bot.Handlers;

public class MessageHandler
{
    private readonly UserStateService _userStateService;

    public MessageHandler(UserStateService userStateService)
    {
        _userStateService = userStateService;
    }

    public async Task HandleMessageAsync(ITelegramBotClient botClient, Message message)
    {
        long chatId = message.Chat.Id;
        string userMessage = message.Text;

        // Если клиент вернулся в главное меню, сбрасываем состояние
        if (userMessage == "Повернутися до головного меню" || userMessage == "/start")
        {
            _userStateService.SetUserState(chatId, false); // Клиент НЕ общается с менеджером

            await botClient.SendTextMessageAsync(chatId,
                "Вітаємо! Це служба підтримки hive.report (ФОП Глоба О.В.).\r\nЩоб продовжити далі та зв’язатися з нами або отримати інформацію, натисніть\r\nкнопку👇\r\nМи цінуємо нашу співпрацю❤️",
                replyMarkup: Main.GetMain());
        }
        // Если клиент хочет связаться с менеджером
        else if (userMessage == "Зв’язатися з командою")
        {
            _userStateService.SetUserState(chatId, true); // Клиент начал общение с менеджером

            await botClient.SendTextMessageAsync(chatId,
                "Зараз менеджер приєднається до Вас!\r\nПоки опишіть ситуацію. Дякую!", replyMarkup: FixedReplyKeyboard1.GetReplyKeyboard());
        }
        // Если клиент НЕ общается с менеджером и отправил неизвестное сообщение
        else if (!_userStateService.GetUserState(chatId))
        {
            await botClient.SendTextMessageAsync(chatId,
                "Бот не розуміє вас",
                replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
        }
    }
}
