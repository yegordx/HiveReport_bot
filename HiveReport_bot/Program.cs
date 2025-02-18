using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using System;
using System.Threading;
using System.Threading.Tasks;
using HiveReport_bot.Handlers;
using HiveReport_bot.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<ITelegramBotClient>(new TelegramBotClient("7675831655:AAEKgcV6b6FeVdPFEOWcnK44_-FkwhFxBQ0"));

                services.AddSingleton<UserStateService>();
                services.AddSingleton<UpdateHandler>();
                services.AddSingleton<MessageHandler>();
                services.AddSingleton<CallbackHandler>();

                services.AddHostedService<TelegramBotService>();
            })
            .Build();

        await host.RunAsync();
    }
}



