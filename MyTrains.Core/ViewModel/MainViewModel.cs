using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MyTrains.Core.Contracts.ViewModel;

namespace MyTrains.Core.ViewModel
{
    public class MainViewModel : MvxViewModel, IMainViewModel
    {
        private readonly Lazy<SearchJourneyViewModel> _searchJourneyViewModel;
        private readonly Lazy<SavedJourneysViewModel> _savedJourneysViewModel;
        private readonly Lazy<SettingsViewModel> _settingsViewModel;

        public SearchJourneyViewModel SearchJourneyViewModel => _searchJourneyViewModel.Value;

        public SavedJourneysViewModel SavedJourneysViewModel => _savedJourneysViewModel.Value;

        public SettingsViewModel SettingsViewModel => _settingsViewModel.Value;

        public MainViewModel()
        {
            _searchJourneyViewModel = new Lazy<SearchJourneyViewModel>(Mvx.IocConstruct<SearchJourneyViewModel>);
            _savedJourneysViewModel = new Lazy<SavedJourneysViewModel>(Mvx.IocConstruct<SavedJourneysViewModel>);
            _settingsViewModel = new Lazy<SettingsViewModel>(Mvx.IocConstruct<SettingsViewModel>);
        }

        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel>();
        }

        public void ShowSearchJourneys()
        {
            ShowViewModel<SearchJourneyViewModel>();
        }
    }
}