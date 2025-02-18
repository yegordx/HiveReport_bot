using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace HiveReport_bot.Keyboards;

public static class Main
{
    public static InlineKeyboardMarkup GetMain()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Зв’язатися з командою", "call_team") },
            new [] { InlineKeyboardButton.WithCallbackData("Отримати довідкову інформацію", "get_info") },
            new [] { InlineKeyboardButton.WithCallbackData("Про нас", "about_us") },
            new [] { InlineKeyboardButton.WithCallbackData("Контакти", "contacts") }
        });
    }
}
