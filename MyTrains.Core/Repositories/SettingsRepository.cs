using System.Collections.Generic;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class SettingsRepository: ISettingsRepository
    {
        private static readonly List<Currency> AllAvailableCurrencies = new List<Currency>
        {
            new Currency { CurrencyId = 1, CurrencyName = "Dollar", CurrencySymbol = "$"},
            new Currency { CurrencyId = 2, CurrencyName = "Euro", CurrencySymbol = "€"},
            new Currency { CurrencyId = 3, CurrencyName = "Pound", CurrencySymbol = "£"}
        };
        public List<Currency> GetAvailableCurrencies()
        {
            return AllAvailableCurrencies;
        }

        public Currency GetCurrencyById(int currencyId)
        {
            return AllAvailableCurrencies[currencyId];
        }

        public string GetAboutContent()
        {
            return "Leverage agile frameworks to provide a robust synopsis for high level overviews. Iterative approaches to corporate strategy foster collaborative thinking to further the overall value proposition. Organically grow the holistic world view of disruptive innovation via workplace diversity and empowerment.";
        }
    }
}