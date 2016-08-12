using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Extensions;
using MyTrains.Core.Model;
using MyTrains.Core.Model.App;

namespace MyTrains.Core.ViewModel
{
    public class SearchJourneyViewModel : BaseViewModel, ISearchJourneyViewModel
    {
        private readonly ICityDataService _cityDataService;
        private readonly IConnectionService _connectionService;
        private readonly IDialogService _dialogService;
        private City _selectedFromCity;
        private City _selectedToCity;
        private ObservableCollection<City> _fromCities;
        private ObservableCollection<City> _toCities;
        private ObservableCollection<string> _possibleTimes;
        private DateTime _selectedDate;
        private string _selectedHour;

        public City SelectedFromCity
        {
            get { return _selectedFromCity; }
            set
            {
                if (_selectedFromCity != value)
                {
                    _selectedFromCity = value;
                    RaisePropertyChanged(() => SelectedFromCity);
                }
            }
        }

        public City SelectedToCity
        {
            get { return _selectedToCity; }
            set
            {
                if (_selectedToCity != value)
                {
                    _selectedToCity = value;
                    RaisePropertyChanged(() => SelectedToCity);
                }
            }
        }

        public ObservableCollection<City> FromCities
        {
            get { return _fromCities; }
            set
            {
                _fromCities = value;
                RaisePropertyChanged(() => FromCities);
            }
        }

        public ObservableCollection<City> ToCities
        {
            get { return _toCities; }
            set
            {
                _toCities = value;
                RaisePropertyChanged(() => ToCities);
            }
        }

        public ObservableCollection<string> PossibleTimes
        {
            get { return _possibleTimes; }
            set
            {
                _possibleTimes = value;
                RaisePropertyChanged(() => PossibleTimes);
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                RaisePropertyChanged(() => SelectedDate);
            }
        }

        public string SelectedHour
        {
            get { return _selectedHour; }
            set
            {
                if (value != _selectedHour)
                {
                    _selectedHour = value;

                    RaisePropertyChanged(() => SelectedHour);
                }
            }
        }

        public IMvxCommand SearchCommand
        {
            get
            {
                return new MvxCommand(() =>
                    ShowViewModel<SearchResultViewModel>(new SearchParameters
                    {
                        DepartureTime = SelectedHour, FromCityId = SelectedFromCity.CityId, ToCityId = SelectedToCity.CityId, JourneyDate = SelectedDate
                    }));
            }
        }

        public SearchJourneyViewModel(IMvxMessenger messenger, 
            ICityDataService cityDataService, 
            IConnectionService connectionService, 
            IDialogService dialogService) : base(messenger)
        {
            _cityDataService = cityDataService;
            _connectionService = connectionService;
            _dialogService = dialogService;

            SelectedDate = DateTime.Today;
        }

        public override async void Start()
        {
            base.Start();

            await ReloadDataAsync();
        }


        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            if (_connectionService.CheckOnline())
            {
                await LoadCities();

                SelectedFromCity = FromCities[0];
                SelectedToCity = FromCities[0];

                PossibleTimes = new ObservableCollection<string>();
                GetDepartureTimes();

                SelectedHour = PossibleTimes[0];
            }
            else
            {
                await _dialogService.ShowAlertAsync("No internet available", "My Trains says...", "OK");
                //maybe we can navigate to a start page here, for you to add to this code base!
            }
        }

        internal async Task LoadCities()
        {
            FromCities = (await _cityDataService.GetAllCities()).ToObservableCollection();
            ToCities = (await _cityDataService.GetAllCities()).ToObservableCollection();
        }

        private void GetDepartureTimes()
        {
            PossibleTimes.Add("9:00 am");
            PossibleTimes.Add("9:15 am");
            PossibleTimes.Add("9:30 am");
            PossibleTimes.Add("9:45 am");
            PossibleTimes.Add("10:00 am");
            PossibleTimes.Add("10:15 am");
            PossibleTimes.Add("10:30 am");
            PossibleTimes.Add("10:45 am");
            PossibleTimes.Add("11:00 am");
            PossibleTimes.Add("11:15 am");
            PossibleTimes.Add("12:30 am");
            PossibleTimes.Add("12:45 am");
        }
    }
}