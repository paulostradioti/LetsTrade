namespace LetsTrade.Console.Abstractions
{
    public interface ITradeMapper
    {
        TradeRecord MapFieldsToRecord(string[] fields);
    }
}
