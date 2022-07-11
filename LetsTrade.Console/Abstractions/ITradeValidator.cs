namespace LetsTrade.Console.Abstractions
{
    public interface ITradeValidator
    {
        bool ValidateTrades(string[] fields, int lineCount);
    }
}
