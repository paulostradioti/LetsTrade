using LetsTrade.Console;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = File.OpenRead("trades.txt");

            ITradeDataReader tradeDataReader = new TextFileTradeDataReader();
            ITradesLogger tradeLogger = new ConsoleITradesLogger();
            ITradeValidator tradeValidator = new TradeValidator(tradeLogger);
            ITradeMapper tradeMapper = new TradeMapper();
            ITradeParser tradeParser = new TradeParser(tradeValidator, tradeMapper);
            ITradeSaver tradeSaver = new TradeSaver(tradeLogger);

            var tradeProcessor = new TradeProcessor(tradeDataReader, tradeParser, tradeSaver);
            tradeProcessor.ProcessTrades(stream);
            
            stream.Close();

            Console.ReadKey();
        }
    }
}
