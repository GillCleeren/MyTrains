using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Extensions;
using MyTrains.Core.Messages;
using MyTrains.Core.Model;
using MyTrains.Core.Model.App;

namespace MyTrains.Core.ViewModel
{
    public class SearchResultViewModel : BaseViewModel, ISearchResultViewModel
    {
        private readonly IJourneyDataService _journeyDataService;
        private int _fromCityId;
        private int _toCityId;
        private DateTime _journeyDate;
        private string _departureTime;
        private ObservableCollection<Journey> _journeys;

        public ObservableCollection<Journey> Journeys
        {
            get { return _journeys; }
            set
            {
                _journeys = value;
                RaisePropertyChanged(() => Journeys);
            }
        }

        public MvxCommand<Journey> ShowJourneyDetailsCommand
        {
            get
            {
                return new MvxCommand<Journey>(selectedJourney =>
                {
                    ShowViewModel<JourneyDetailViewModel>
                    (new { journeyId = selectedJourney.JourneyId });
                });
            }
        }

        public MvxCommand ReloadDataCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    Journeys = (await _journeyDataService.SearchJourney(_fromCityId, _toCityId, _journeyDate, DateTime.Parse(_departureTime))).ToObservableCollection();
                });
            }
        }


        public SearchResultViewModel(IMvxMessenger messenger, IJourneyDataService journeyDataService) : base(messenger)
        {
            _journeyDataService = journeyDataService;

            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            Messenger.Subscribe<CurrencyChangedMessage>
                (async message => await ReloadDataAsync());
        }

        public override async void Start()
        {
            base.Start();

            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            Journeys = (await _journeyDataService.SearchJourney(_fromCityId, _toCityId, _journeyDate, DateTime.Parse(_departureTime))).ToObservableCollection();
        }

       

        public void Init(SearchParameters parameters)
        {
            _fromCityId = parameters.FromCityId;
            _toCityId = parameters.ToCityId;
            _journeyDate = parameters.JourneyDate;
            _departureTime = parameters.DepartureTime;
        }
    }
}