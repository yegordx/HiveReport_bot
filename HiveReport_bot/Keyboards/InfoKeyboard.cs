using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace HiveReport_bot.Keyboards;

public static class InfoKeyboard
{
    public static InlineKeyboardMarkup GetInfoKeyboard()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Електронний підпис", "digital_signature_info") },
            new [] { InlineKeyboardButton.WithCallbackData("M.E.Doc", "medoc_info") },
            new [] { InlineKeyboardButton.WithCallbackData("Cashalot", "cashalot_info") },
            new [] { InlineKeyboardButton.WithCallbackData("СОТА", "cota_info") },
            new [] { InlineKeyboardButton.WithCallbackData("СОТА Каса", "cota_cassa_info") },
            new [] { InlineKeyboardButton.WithCallbackData("Виїзд спеціаліста", "call_specialist_info") }
        });
    }
}
