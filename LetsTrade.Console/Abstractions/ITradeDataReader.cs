namespace LetsTrade.Console.Abstractions
{
    public interface ITradeDataReader
    {
        List<string> GetTradeData(Stream stream);
    }
}
