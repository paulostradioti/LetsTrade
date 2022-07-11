namespace LetsTrade.Console.Abstractions
{
    public interface ITradeSaver
    {
        void Save(List<TradeRecord> trades);
    }
}
