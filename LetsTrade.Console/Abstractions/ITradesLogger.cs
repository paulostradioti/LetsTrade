namespace LetsTrade.Console
{
    public interface ITradesLogger
    {
        void LogMessage(string message, params object[] args);
    }
}
