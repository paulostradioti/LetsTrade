using LetsTrade.Console;
using System;
using System.Collections.Generic;
using System.IO;

namespace SingleResponsibilityPrinciple
{
    public class TradeProcessor
    {
        

        ITradeDataReader _tradeDataReader;
        private readonly ITradeParser _tradeParser;

        public TradeProcessor(ITradeDataReader tradeDataReader, ITradeParser tradeParser)
        {
            _tradeDataReader = tradeDataReader;
            _tradeParser = tradeParser;
        }

        public void ProcessTrades(Stream stream)
        {
            var lines = _tradeDataReader.GetTradeData(stream);
            var trades = _tradeParser.Parse(lines);
            SaveTrades(trades);
        }


        private static void SaveTrades(List<TradeRecord> trades)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=localhost;Initial Catalog=TradeDatabase;User Id=lc;Password=P@ssw0rd"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                connection.Close();
            }
            Console.WriteLine("INFO: {0} trades processed", trades.Count);
        }
    }
}
