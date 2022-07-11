namespace LetsTrade.Console
{
    public interface ITradeValidator
    {
        bool ValidateTrades(string[] fields, int lineCount);
    }
}
