using LetsTrade.Console;
using System.Collections.Generic;

namespace SingleResponsibilityPrinciple
{
    public class TradeParser : ITradeParser
    {
        private readonly ITradeValidator _tradeValidator;
        private readonly ITradeMapper tradeMapper;

        public TradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper)
        {
            _tradeValidator = tradeValidator;
            this.tradeMapper = tradeMapper;
        }

        public List<TradeRecord> Parse(List<string> lines)
        {
            var trades = new List<TradeRecord>();
            var lineCount = 1;

            foreach (var line in lines)
            {
                var fields = line.Split(new char[] { ',' });

                if (!_tradeValidator.ValidateTrades(fields, lineCount))
                {
                    continue;
                }

                var trade = tradeMapper.MapFieldsToRecord(fields);

                trades.Add(trade);

                lineCount++;
            }

            return trades;
        }
    }
}
