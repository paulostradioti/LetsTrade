namespace LetsTrade.Console.Abstractions
{
    public interface ITradeProcessor
    {
        void ProcessTrades(Stream stream);
    }
}