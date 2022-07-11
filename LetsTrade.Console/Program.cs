using LetsTrade.Console;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = File.OpenRead("trades.txt");

            ITradeDataReader tradeDataReader = new TextFileTradeDataReader();
            ITradesLogger tradesLogger = new ConsoleITradesLogger();
            ITradeValidator tradeValidator = new TradeValidator(tradesLogger);
            ITradeMapper tradeMapper = new TradeMapper();
            ITradeParser tradeParser = new TradeParser(tradeValidator, tradeMapper);


            var tradeProcessor = new TradeProcessor(tradeDataReader, tradeParser);
            tradeProcessor.ProcessTrades(stream);
            
            stream.Close();

            Console.ReadKey();
        }
    }
}
