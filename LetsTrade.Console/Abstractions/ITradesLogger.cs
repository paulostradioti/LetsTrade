using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsTrade.Console
{
    public interface ITradesLogger
    {
        void LogMessage(string message, params object[] args);
    }
}
