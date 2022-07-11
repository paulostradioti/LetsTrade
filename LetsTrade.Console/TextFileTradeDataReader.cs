using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsTrade.Console.Abstractions;

namespace SingleResponsibilityPrinciple
{
    public class TextFileTradeDataReader : ITradeDataReader
    {
        public List<string> GetTradeData(Stream stream)
        {
            var lines = new List<string>();

            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}
