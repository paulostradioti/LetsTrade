namespace LetsTrade.Console
{
    public interface ITradeDataReader
    {
        List<string> GetTradeData(Stream stream);
    }
}
