using System.Collections.Generic;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class SettingsDataService : ISettingsDataService
    {
        private readonly ISettingsRepository _settingsRepository;
        private Currency _activeCurrency;

        public SettingsDataService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public List<Currency> GetCurrencies()
        {
            return _settingsRepository.GetAvailableCurrencies();
        }

        public Currency GetActiveCurrency()
        {
            return _activeCurrency ?? (_activeCurrency = _settingsRepository.GetCurrencyById(1));
        }

        public void SetActiveCurrency(Currency currency)
        {
            _activeCurrency = currency;
        }

        public string GetAboutContent()
        {
            return _settingsRepository.GetAboutContent();
        }
    }
}