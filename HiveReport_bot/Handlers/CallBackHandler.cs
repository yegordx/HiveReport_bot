using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using HiveReport_bot.Keyboards;
using HiveReport_bot.Services;

namespace HiveReport_bot.Handlers;

public class CallbackHandler
{
    private readonly UserStateService _userStateService;

    public CallbackHandler(UserStateService userStateService)
    {
        _userStateService = userStateService;
    }
    public async Task HandleCallbackAsync(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        string action = callbackQuery.Data;
        long chatId = callbackQuery.Message.Chat.Id;

        switch (action)
        {
            case "call_team":
                _userStateService.SetUserState(chatId, true); //клієнт спілкується з менеджером

                await botClient.SendTextMessageAsync(chatId, "Зараз менеджер приєднається до Вас!\r\nПоки опишіть ситуацію. Дякую �", replyMarkup: FixedReplyKeyboard1.GetReplyKeyboard());
                break;

            case "get_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                await botClient.SendTextMessageAsync(chatId, "Оберіть категорію", replyMarkup:InfoKeyboard.GetInfoKeyboard());
                break;

            case "digital_signature_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "medoc_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "cashalot_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "cota_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "cota_cassa_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "call_specialist_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "about_us":
                await botClient.SendTextMessageAsync(chatId, "Ми пропонуємо програмні продукти №1 для бізнесу з організації електронних\r\nзвітності та документообігу з 2007 року.\r\nЗа час існування компанії ми накопичили багато цінного досвіду та неабиякі\r\nкомпетенції. тому нині ми маємо потужну, вмотивовану та злагоджену команду\r\nпрофесіоналів, яка швидко та якісно організовує весь спектр послуг електронної\r\nзвітності і документообігу: від видачі електронного підпису до найточнішого\r\nналаштування програми та подальшого обслуговування.\r\nНаразі нам довіряє понад 13 тисяч клієнтів, серед який як фізичні особи-підприємці,\r\nтак і представники малого, середнього та великого бізнесу, державні установи.\r\nhive.report - приєднуйтесь до найкращих!", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;

            case "contacts":
                await botClient.SendTextMessageAsync(chatId, "Зв’яжіться з нами зручним для Вас способом”\r\nНаш сайт\r\nМає виводитись повідомлення:\r\n“Наш веб сайт https://hive.report/”\r\nТелефон для звернень\r\nМає виводитись повідомлення:\r\n“Наш телефон +38 (063) 247 66 99", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            default:
                await botClient.SendTextMessageAsync(chatId, "Повний незроз");
                break;
        }
    }
}



//new [] { InlineKeyboardButton.WithCallbackData("Електронний підпис", "digital_signature_info") },
//new[] { InlineKeyboardButton.WithCallbackData("M.E.Doc", "medoc_ingo") },
//new[] { InlineKeyboardButton.WithCallbackData("Cashalot", "cashalot_info") },
//new[] { InlineKeyboardButton.WithCallbackData("СОТА", "cota_info") },
//new[] { InlineKeyboardButton.WithCallbackData("СОТА Каса", "cota_cassa_info") },
//new[] { InlineKeyboardButton.WithCallbackData("Виїзд спеціаліста", "call_specialist_info") }
     