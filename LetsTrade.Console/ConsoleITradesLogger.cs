using LetsTrade.Console;
using System;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleITradesLogger : ITradesLogger
    {
        public void LogMessage(string message, params object[] args) 
            => Console.WriteLine(message, args);
    }
}
