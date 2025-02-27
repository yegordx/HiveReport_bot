using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace HiveReport_bot.Keyboards;

public static class InlineKeyboardFactory
{
    public static InlineKeyboardMarkup GetKeyboard(string type)
    {
        return type switch
        {
        "main" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Зв’язатися з командою", "call_team") },
            new [] { InlineKeyboardButton.WithCallbackData("Отримати довідкову інформацію", "get_info") },
            new [] { InlineKeyboardButton.WithCallbackData("Про нас", "about_us") },
            new [] { InlineKeyboardButton.WithCallbackData("Контакти", "contacts") }
        }),
        "get_info" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Електронний підпис", "digital_signature_info") },
            new [] { InlineKeyboardButton.WithCallbackData("M.E.Doc", "medoc_info") },
            new [] { InlineKeyboardButton.WithCallbackData("Cashalot", "cashalot_info") },
            new [] { InlineKeyboardButton.WithCallbackData("СОТА", "cota_info") },
            new [] { InlineKeyboardButton.WithCallbackData("СОТА Каса", "cota_cassa_info") },
            new [] { InlineKeyboardButton.WithCallbackData("Виїзд спеціаліста", "call_specialist_info") }
        }),
        "digital_signature_info" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Перелік документів для КЕП", "documents_for_CES") },
            new [] { InlineKeyboardButton.WithCallbackData("Як продовжити підпис онайн", "prolongation_CES") },
            new [] { InlineKeyboardButton.WithCallbackData("Як зареєструвати КЕП в ДПС\r\n", "registration_CES") },
            new [] { InlineKeyboardButton.WithCallbackData("Термінологія", "terminology_CES") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "get_info") }
        }),
        "documents_for_CES" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithUrl("Для юридичних осіб", "https://uakey.com.ua/files/uploads/86fef5c0d65b30a81c346a67a0fa1deb.pdf\r\n") },
            new [] { InlineKeyboardButton.WithUrl("Для фізичних осіб", "https://uakey.com.ua/files/uploads/a28af51d52c44abd882f4e76bdcf0f57.pdf") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "digital_signature_info") }
        }),
        "prolongation_CES" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithUrl("Через M.E.Doc", "https://hive.report/news/yak-prodovzhiti-diyu-svogo-sertifikata-cherez-m-e-doc/") },
            new [] { InlineKeyboardButton.WithCallbackData("Через сайт", "https://hive.report/news/yak-prodovzhiti-diyu-svogo-sertifikata-onlajn/ ") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "digital_signature_info") }
        }),
        "registration_CES" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Отримали нові підписи, але старі ще діють", "collision_of_CES") },
            new [] { InlineKeyboardButton.WithCallbackData("Новий підпис", "new_CES") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "digital_signature_info") }
        }),
        "terminology_CES" => new InlineKeyboardMarkup(new[]
            {
            new [] { InlineKeyboardButton.WithCallbackData("Сертифікат ключа", "certificate_term") },
            new [] { InlineKeyboardButton.WithCallbackData("Електронний ключ", "digital_key_term") },
            new [] { InlineKeyboardButton.WithCallbackData("Електронний підпис", "digital_signature_term") },
            new [] { InlineKeyboardButton.WithCallbackData("Токен(захищений носій)", "tocken_term") },
            new [] { InlineKeyboardButton.WithCallbackData("ВПР", "vpr_term") },
            new [] { InlineKeyboardButton.WithCallbackData("Варта", "varta_term ") },
            new [] { InlineKeyboardButton.WithCallbackData("Електронний документ", "digital_document_term") },
            new [] { InlineKeyboardButton.WithCallbackData("Електронний документообіг", "digital_doc_flow_term") },
            new [] { InlineKeyboardButton.WithCallbackData("Обов’язковий реквізит електронного документу", "requisites_term") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "digital_signature_info") }
        }),
        "medoc_info" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Модулі M.E.Doc", "moduls_medoc") },
            new [] { InlineKeyboardButton.WithCallbackData("Довідник", "faq_medoc") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "get_info") }
        }),
        "moduls_medoc" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Звітність", "report_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("Облік ПДВ", "VAT_accounting_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("Інтеграція з обліковими системами", "integration_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("Електронний документообіг", "digital_doc_flow_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("Зарплата", "salary_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("Звітність до НБУ для небанківських установ", "NBU_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("iXBRL", "iXBRL_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("Облік акцизного податку", "excise_mod") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "medoc_info") }
        }),
        "faq_medoc" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Як підтягнути нову ліцензію", "new_license_faq") },
            new [] { InlineKeyboardButton.WithCallbackData("Де знайти інформацію стосовно програми?", "prog_info_faq") },
            new [] { InlineKeyboardButton.WithCallbackData("Назад", "medoc_info") }
        }),
        "contacts" => new InlineKeyboardMarkup(new[]
        {
            new [] { InlineKeyboardButton.WithCallbackData("Наш сайт", "site_contact") },
            new [] { InlineKeyboardButton.WithCallbackData("Телефон для звернень", "phone_contact") },
            new [] { InlineKeyboardButton.WithCallbackData("Адреса відділення", "address_contact") }
        }),
        };
    }
}
