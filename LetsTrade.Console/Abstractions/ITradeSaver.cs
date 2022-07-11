namespace LetsTrade.Console
{
    public interface ITradeSaver
    {
        void Save(List<TradeRecord> trades);
    }
}
