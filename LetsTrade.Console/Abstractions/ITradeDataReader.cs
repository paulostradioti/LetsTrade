using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsTrade.Console
{
    public interface ITradeDataReader
    {
        List<string> GetTradeData(Stream stream);
    }
}
