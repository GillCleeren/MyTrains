namespace MyTrains.Core.Model
{
    public class Currency
    {
        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }

        public int CurrencyId { get; set; }

        public override string ToString()
        {
            return $"{CurrencyName} ({CurrencySymbol})";
        }
    }
}