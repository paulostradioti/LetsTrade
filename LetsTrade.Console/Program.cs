using LetsTrade.Console;
using LetsTrade.Console.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace SingleResponsibilityPrinciple
{
    class Program
    {

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddScoped<ITradeDataReader, TextFileTradeDataReader>()
                .AddScoped<ITradesLogger, ConsoleITradesLogger>()
                .AddScoped<ITradeValidator, TradeValidator>()
                .AddScoped<ITradeMapper, TradeMapper>()
                .AddScoped<ITradeParser, TradeParser>()
                .AddScoped<ITradeSaver, TradeSaver>()
                .AddScoped<ITradeProcessor, TradeProcessor>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            using (var stream = File.OpenRead("trades.txt"))
            {
                var tradesProcessor = serviceProvider.GetService<ITradeProcessor>();
                tradesProcessor.ProcessTrades(stream);
            }
        }
    }
}
