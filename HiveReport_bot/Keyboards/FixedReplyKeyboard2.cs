using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace HiveReport_bot.Keyboards;

public static class FixedReplyKeyboard2
{
    public static ReplyKeyboardMarkup GetReplyKeyboard()
    {
        return new ReplyKeyboardMarkup(new[]
        {
        new KeyboardButton[] { "Зв’язатися з командою" },
        new KeyboardButton[] { "Повернутися до головного меню"}
    })
        {
            ResizeKeyboard = true, 
            OneTimeKeyboard = false
        };
    }
}
