using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsTrade.Console
{
    public interface ITradeParser
    {
        List<TradeRecord> Parse(List<string> lines);
    }
}
