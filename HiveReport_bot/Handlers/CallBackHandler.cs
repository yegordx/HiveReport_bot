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
using Telegram.Bot.Types.Enums;

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

                await botClient.SendTextMessageAsync(chatId, "Зараз менеджер приєднається до Вас! Поки опишіть ситуацію. Дякую!", replyMarkup: FixedReplyKeyboard1.GetReplyKeyboard());
                break;

            case "get_info":
                await botClient.SendTextMessageAsync(chatId, "Сконтактуйте з нами для отримання консультації", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                await botClient.SendTextMessageAsync(chatId, "Оберіть категорію", replyMarkup: InlineKeyboardFactory.GetKeyboard("get_info"));
                break;

            case "digital_signature_info":
                await botClient.SendTextMessageAsync(chatId, "Кваліфікований електронний підпис має таку ж юридичну силу, як і власноручний підпис, та має презумпцію його відповідності власноручному підпису (П.4 ст. 18 ЗУ №2155-VII від 5.10.2017 р.). Ми формуємо та обслуговуємо електронні підпис від ЦСК “Україна”. Його можна використовувати на всіх державних порталах та в наших продуктів. Якщо не маєте КЕП, пропонуємо завітати до нас в офіс за записом або замовити виїзд спеціаліста для формування.", replyMarkup: InlineKeyboardFactory.GetKeyboard("digital_signature_info"));
                break;
            case "documents_for_CES":
                await botClient.SendTextMessageAsync(chatId, "Формування підпису відбувається при особистій присутності підписанта з необхідним пакетом документів. Перелік документів можете знайти нижче.", replyMarkup: InlineKeyboardFactory.GetKeyboard("documents_for_CES"));
                break;
            case "medoc_info":
                await botClient.SendTextMessageAsync(chatId, "Найпопулярніша програма в Україні для подачі звітності та введення електронного документообігу", replyMarkup: InlineKeyboardFactory.GetKeyboard("medoc_info"));
                break;
            case "moduls_medoc":
                await botClient.SendTextMessageAsync(chatId, "Обирайте рішення для своєчасної звітності та миттєвого обміну електронними документами! Для замовлення, сконтактуйте з нами", replyMarkup: InlineKeyboardFactory.GetKeyboard("moduls_medoc"));
                break;

            case "report_mod":
                await botClient.SendTextMessageAsync(chatId, "Майте повний контроль над власною звітністю без зусиль! Цей основний модуль програми дозволяє створювати, імпортувати та відправляти звіти до ДПС, НБУ, ДСС та інших. Є вбудовані перевірки за методикою регуляторів з порадами та актуальні бланки!");
                break;
            case "VAT_accounting_mod":
                await botClient.SendTextMessageAsync(chatId, "Не втрачайте жодної копійки на ПДВ! Цей модуль дозволяє тримати всі податкові документи в одному місці та надзвичайно корисний для платників ПДВ. Є вбудовані інструменти для автоматизації реєстрації ПН.");
                break;
            case "integration_mod":
                await botClient.SendTextMessageAsync(chatId, "M.E.Doc Інтеграція - це швидкий та зручний обмін податковими накладними, первинними документами та регламентованою звітністю між M.E.Doc і обліковою системою без додаткових налаштувань конфігурації.");
                break;
            case "digital_doc_flow_mod":
                await botClient.SendTextMessageAsync(chatId, "“Це миттєвий та законний обмін будь-якими електронними документами з вашими контрагентами. M.E.Doc забезпечує вільну комунікацію з 90% всіх контрагентів, що здійснюють діяльність в межах України! Крім цього, наявна автоматизація електронного документообігу.");
                break;
            case "salary_mod":
                await botClient.SendTextMessageAsync(chatId, "Модуль, призначений для розрахунку і нарахування заробітної плати, обліку та управління персоналом.");
                break;
            case "NBU_mod":
                await botClient.SendTextMessageAsync(
                    chatId,
                    "Модуль для небанківських фінустанов, з усіма комплектами бланків, що звітуються до НБУ в електронному вигляді \n\n<i>З 1 липня 2020 року НФУ — небанківські фінансові установи мають звітувати до НБУ виключно у електронному вигляді, відповідно до вимог Закону України «Про внесення змін до деяких законодавчих актів України, щодо удосконалення функцій із державного регулювання ринків фінансових послуг» від 12.09.2019 р. № 79-ІХ (Закон про «спліт»)</i>",
                    parseMode: ParseMode.Html
                );
                break;
            case "iXBRL_mod":
                await botClient.SendTextMessageAsync(chatId, "Зручна та легка подача фінзвітності за міжнародними стандартами для\r\nпідприємств, що прагнуть прозорості даних.\r\nКому потрібно подавати фінзвітність у iXBRL?\r\n● банкам\r\n● страховим компаніям\r\n● публічним акціонерним товариствам\r\n● небанківським фінансовим установам\r\n● підприємствам газовидобувної галузі\r\n● профучасникам ринку цінних паперів\r\n● а також іншим підприємствам, які прагнуть мати прозору звітність для інвесторів\r\nXBRL (розширювана мова ділової звітності) — це міжнародний стандарт створення\r\nфінзвітності, яку отримують регулятори, інвестори, кредитори, партнери та інші\r\nзацікавлені особи. iXBRL — звітність, яку легко можна переглядати просто у\r\nінтернет-браузері");
                break;
            case "excise_mod":
                await botClient.SendTextMessageAsync(chatId, "Для виробників та реалізаторів підакцизних товарів. Розроблений для роботи із системою електронного адміністрування реалізації\r\nпального та спирту (СЕАРП та СЕ) та поводження з товарно-транспортними\r\nнакладними.");
                break;

            case "faq_medoc":
                await botClient.SendTextMessageAsync(chatId, "Корисно знати", replyMarkup: InlineKeyboardFactory.GetKeyboard("moduls_medoc"));
                break;
            case "new_license_faq":
                await botClient.SendTextMessageAsync(chatId, "Для завантаження в програму оновленої ліцензії необхідно зробити наступні дії: Адміністрування ️ Керування кодом доступ ➡️ Завантажти ➡️ OK ➡️ Зберегти");
                break;
            case "prog_info_faq":
                await botClient.SendTextMessageAsync(chatId, "В програмі наявна Довідка, але вона не покриває весь спектр питань, які часом виникають. Якщо потрібна консультація, сконтактуйте з нами через зручний Вам спосіб:\r\n● Телефон +38 (063) 247 66 99\r\n● Пошта support@hive.report чи info@hive.report\r\n● Telegram бот\r\n● Чат на сайті hive.report\r\nБудемо раді Вашому зверненню!");
                break;

            case "prolongation_CES":
                await botClient.SendTextMessageAsync(chatId, "Якщо термін підпису не закінчився, тоді є наступні шляхи продовження", replyMarkup: InlineKeyboardFactory.GetKeyboard("prolongation_CES"));
                break;
            case "registration_CES":
                await botClient.SendTextMessageAsync(chatId, "Для подачі звітності, підписаної КЕП, до ДПС необхідно його зареєструвати. Є два основних випадки.", replyMarkup: InlineKeyboardFactory.GetKeyboard("registration_CES"));
                break;
            case "collision_of_CES":
                await botClient.SendTextMessageAsync(chatId, "Вам потрібно відправити «Повідомлення про надання інформації щодо кваліфікованого електронного підпису» (F/J1391104). У табличну частину даного звіту додайте всі нові КЕП (бухгалтера, директора та печатки). Будьте уважні під час підписання повідомлення! Спочатку підписуєте усіма новими ключами у тому ж порядку як вони відображаються у табличній частині. А вже потім ключами у яких термін дії уже закінчується. Ключ шифрування печатки під час відправлення можна обрати будь-який. Коли на повідомлення ви отримаєте першу та другу квитанцію, статуси якої буде «Прийнято», вже можна користуватися новими КЕП. Якщо будь-яка квитанція має статус «Не прийнято» – зверніть увагу на «Виявлені помилки/зауваження».");
                break;
            case "new_CES":
                await botClient.SendTextMessageAsync(chatId, "Щоб зареєструвати КЕП потрібно подати будь-який звіт чи запит до контролюючого органу. Але на практиці ми радимо відправити «Запит про отримання витягу щодо стану розрахунків з бюджетами та цільовими фондами за даними органів ДПС» (F/J1300207). Його потрібно підписати новим діючим КЕП керівника та печатки (за наявності). У відповідь ви отримаєте квитанцію з результатом обробки «Витяг з інформаційної системи органів ДПС щодо стану розрахунків платника з бюджетом та цільовими фондами» (F/J1400204) та «Повідомлення про набуття суб'єктом статусу електронного документообігу» (F/J1391099). Це означає, що у податковій зареєстровано КЕП керівника та печатки підприємства.");
                break;
            case "terminology_CES":
                await botClient.SendTextMessageAsync(chatId, "Термінологія", replyMarkup: InlineKeyboardFactory.GetKeyboard("terminology_CES"));
                break;


            case "certificate_term":
                await botClient.SendTextMessageAsync(chatId, "Сертифікатом ключа виступає документ, який видається АЦСК, і засвідчує чинність і належність відкритого ключа власнику.");
                break;
            case "digital_key_term":
                await botClient.SendTextMessageAsync(chatId, "Електронний ключ — апаратний засіб, призначений для захисту програмного забезпечення і даних від копіювання, нелегального використання та несанкціонованого розповсюдження.");
                break;
            case "digital_signature_term":
                await botClient.SendTextMessageAsync(chatId, "Електронний підпис — це електронні дані, які забезпечують цілісність документів та ідентифікують особу. / юридично значущий аналог власноручного підпису на документі.");
                break;
            case "tocken_term":
                await botClient.SendTextMessageAsync(chatId, "Токен — компактний пристрій, призначений для забезпечення інформаційної безпеки користувача, також використовується для ідентифікації його власника, безпечного віддаленого доступу до інформаційних ресурсів і т. д. Зазвичай, це фізичний пристрій, що використовується для спрощення аутентифікації.");
                break;
            case "vpr_term":
                await botClient.SendTextMessageAsync(chatId, "Відокремлений пункт реєстрації (ВПР) — підрозділ надавача електронних довірчих послуг, який на підставі наказу НЕДП (його керівника) здійснює реєстрацію підписувачів з дотриманням вимог Закону та законодавства у сфері захисту інформації.");
                break;
            case "varta_term":
                await botClient.SendTextMessageAsync(chatId, "Варта — компонент, що входить до складу прикладного ПЗ, який є засобом криптографічного захисту та виконує функції накладання підпису на заявки та зашифрування їх перед відправкою телекомунікаційними засобами зв’язку. Необхідний для функціонування КЕП.");
                break;
            case "digital_document_term":
                await botClient.SendTextMessageAsync(chatId, "Електронний документ — документ, інформація в якому зафіксована у вигляді електронних даних, включаючи обов’язкові реквізити документа. Електронний документ може бути створений, переданий, збережений, відтворений електронними засобами у візуальну форму.");
                break;
            case "digital_doc_flow_term":
                await botClient.SendTextMessageAsync(chatId, "Електронний документообіг — сукупність процесів створення, оброблення, відправлення, передавання, одержання, зберігання, використання, знищення електронних документів, які виконуються із застосуванням перевірки цілісності та у разі необхідності з підтвердженням факту одержання таких документів.");
                break;
            case "requisites_term":
                await botClient.SendTextMessageAsync(chatId, "Обов’язковим реквізитом електронного документу є електронний підпис, який використовується для ідентифікації автора та/або підписанта електронного документа іншими суб’єктами електронного документообігу. Накладанням електронного підпису закінчується створення електронного документу.");
                break;


            case "cashalot_info":
                await botClient.SendTextMessageAsync(chatId, "Сучасна альтернатива традиційним касовим апаратам!\r\nОсновні функції:\r\n● Реєстрація чеків\r\n● Мобільний додаток з ПРРО\r\n● Аналітика по чекам\r\n● Складський облік\r\n● Ведення замовлень\r\n● Потужний API для інтеграції з Вашими середовищами\r\nРеєструйте касу за 2 хвилини і пориньте в гнучку та потужну систему для Вашого\r\nбізнесу!", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "cota_info":
                await botClient.SendTextMessageAsync(chatId, "Це спрощений та полегшений аналог програми M.E.Doc, з яким можна працювати\r\nонлайн через браузер. Не потребує встановлення програми.\r\nНайкраще підходить для ФОП!", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "cota_cassa_info":
                await botClient.SendTextMessageAsync(chatId, "Онлайн сервіс для фіскалізації чеків та проведення платіжних операцій.\r\nПідходить для малого та середнього бізнесу.\r\nКомфортний та легкий в користуванні.\r\nТакож має можливість заповнити та відправити необхідні документи для початку\r\nроботи безпосередньо на сервісі.", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "call_specialist_info":
                await botClient.SendTextMessageAsync(chatId, "Формування КЕП вимагає особистої присутності підписанта, натомість ми пропонуємо заощадити Ваш час та викликати спеціаліста до Вашого офісу. Виїзд працює в межах м. Київ.\r\nТакож спеціаліст може налаштувати та інсталювати програму, що ми обслуговуємо.\r\nДля замовлення виїзду, зв’яжіться з нами.", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;
            case "about_us":
                await botClient.SendTextMessageAsync(chatId, "Ми пропонуємо програмні продукти №1 для бізнесу з організації електронних\r\nзвітності та документообігу з 2007 року.\r\nЗа час існування компанії ми накопичили багато цінного досвіду та неабиякі\r\nкомпетенції. тому нині ми маємо потужну, вмотивовану та злагоджену команду\r\nпрофесіоналів, яка швидко та якісно організовує весь спектр послуг електронної\r\nзвітності і документообігу: від видачі електронного підпису до найточнішого\r\nналаштування програми та подальшого обслуговування.\r\nНаразі нам довіряє понад 13 тисяч клієнтів, серед який як фізичні особи-підприємці,\r\nтак і представники малого, середнього та великого бізнесу, державні установи.\r\nhive.report - приєднуйтесь до найкращих!", replyMarkup: FixedReplyKeyboard2.GetReplyKeyboard());
                break;


            case "contacts":
                await botClient.SendTextMessageAsync(chatId, "Зв’яжіться з нами зручним для Вас способом", replyMarkup: InlineKeyboardFactory.GetKeyboard("contacts"));
                break;
            case "site_contact":
                await botClient.SendTextMessageAsync(chatId, "Зв’яжіться з нами зручним для Вас способом");
                break;
            case "phone_contact":
                await botClient.SendTextMessageAsync(chatId, "Наш телефон +38 (063) 247 66 99");
                break;
            case "address_contact":
                await botClient.SendTextMessageAsync(chatId, "Наше відділення знаходиться за адресою м. Київ, вул. Жилянська, 43Б, оф. 5. Пройдіть через арку та натисніть цифру 5 на вході. Для формування підпису, будь ласка, сконтактуйте для створення запису на певний час.");
                break;


            default:
                await botClient.SendTextMessageAsync(chatId, "Повний незроз");
                break;
        }
    }
}