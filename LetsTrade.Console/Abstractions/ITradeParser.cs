namespace LetsTrade.Console
{
    public interface ITradeParser
    {
        List<TradeRecord> Parse(List<string> lines);
    }
}
