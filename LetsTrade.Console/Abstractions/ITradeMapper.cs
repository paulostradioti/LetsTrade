namespace LetsTrade.Console
{
    public interface ITradeMapper
    {
        TradeRecord MapFieldsToRecord(string[] fields);
    }
}
