using LetsTrade.Console;

namespace SingleResponsibilityPrinciple
{
    public class TradeProcessor
    {
        private readonly ITradeDataReader _tradeDataReader;
        private readonly ITradeParser _tradeParser;
        private readonly ITradeSaver _tradeSaver;

        public TradeProcessor(ITradeDataReader tradeDataReader, ITradeParser tradeParser, ITradeSaver tradeSaver)
        {
            _tradeDataReader = tradeDataReader;
            _tradeParser = tradeParser;
            _tradeSaver = tradeSaver;
        }

        public void ProcessTrades(Stream stream)
        {
            var lines = _tradeDataReader.GetTradeData(stream);
            var trades = _tradeParser.Parse(lines);
            _tradeSaver.Save(trades);
        }
    }
}
