namespace LetsTrade.Console.Abstractions
{
    public interface ITradesLogger
    {
        void LogMessage(string message, params object[] args);
    }
}
