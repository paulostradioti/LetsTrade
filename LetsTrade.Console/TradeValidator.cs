using LetsTrade.Console;

namespace SingleResponsibilityPrinciple
{
    public class TradeValidator : ITradeValidator
    {
        private readonly ITradesLogger _tradesLogger;

        public TradeValidator(ITradesLogger tradesLogger)
        {
            _tradesLogger = tradesLogger;
        }

        public bool ValidateTrades(string[] fields, int lineCount)
        {
            if (fields.Length != 3)
            {
                _tradesLogger.LogMessage("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount, fields.Length);
                return false;
            }

            if (fields[0].Length != 6)
            {
                _tradesLogger.LogMessage("WARN: Trade currencies on line {0} malformed: '{1}'", lineCount, fields[0]);
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(fields[1], out tradeAmount))
            {
                _tradesLogger.LogMessage("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount, fields[1]);
                return false;
            }

            decimal tradePrice;
            if (!decimal.TryParse(fields[2], out tradePrice))
            {
                _tradesLogger.LogMessage("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
                return false;
            }

            return true;
        }
    }
}
