using System.Collections.Generic;
using MyTrains.Core.Model;

namespace MyTrains.Core.Contracts.Services
{
    public interface ISettingsDataService
    {
        List<Currency> GetCurrencies();
        Currency GetActiveCurrency();
        void SetActiveCurrency(Currency currency);
        string GetAboutContent();
    }
}