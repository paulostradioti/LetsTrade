namespace LetsTrade.Console.Abstractions
{
    public interface ITradeParser
    {
        List<TradeRecord> Parse(List<string> lines);
    }
}
