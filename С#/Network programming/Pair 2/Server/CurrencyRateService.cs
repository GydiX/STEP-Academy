namespace CurrencyServer
{
    public class CurrencyRateService
    {
        private readonly Dictionary<(string, string), double> _exchangeRates = new()
        {
            { ("USD", "EURO"), 0.94 },
            { ("EURO", "USD"), 1.06 },
            { ("USD", "GBP"), 0.75 },
            { ("GBP", "USD"), 1.33 },
            { ("EURO", "GBP"), 0.85 },
            { ("GBP", "EURO"), 1.18 },
        };

        public string GetCurrencyRate(string request)
        {
            var currencies = request.Split(' ');
            if (currencies.Length != 2)
                return "Invalid request. Format: <CURRENCY1> <CURRENCY2>";

            string fromCurrency = currencies[0].ToUpper();
            string toCurrency = currencies[1].ToUpper();

            if (_exchangeRates.TryGetValue((fromCurrency, toCurrency), out double rate))
            {
                return $"{fromCurrency} to {toCurrency}: {rate}";
            }

            return "Exchange rate not found.";
        }
    }
}
