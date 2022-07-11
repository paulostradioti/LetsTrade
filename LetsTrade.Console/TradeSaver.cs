namespace LetsTrade.Console
{
    public class TradeSaver : ITradeSaver
    {
        private readonly ITradesLogger _logger;

        public TradeSaver(ITradesLogger logger)
        {
            _logger = logger;
        }

        public void Save(List<TradeRecord> trades)
        {
            using (var connection = new Microsoft.Data.SqlClient.SqlConnection("Data Source=localhost;Initial Catalog=TradeDatabase;User Id=lc;Password=P@ssw0rd"))
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
            _logger.LogMessage("INFO: {0} trades processed", trades.Count);
        }
    }
}
