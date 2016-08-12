using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Contracts.ViewModel;
using MyTrains.Core.Model;
using MvvmCross.Platform.Platform;

namespace MyTrains.Core.ViewModel
{
    public class JourneyDetailViewModel : BaseViewModel, IJourneyDetailViewModel
    {
        private readonly IJourneyDataService _journeyDataService;
        private readonly ISavedJourneyDataService _savedJourneyDataService;
        private readonly IDialogService _dialogService;
        private readonly IUserDataService _userDataService;
        private Journey _selectedJourney;
        private int _journeyId;
        private int _numberOfTravellers;

        public MvxCommand AddToSavedJourneysCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    await _savedJourneyDataService.AddSavedJourney
                    (_userDataService.GetActiveUser().UserId, SelectedJourney.JourneyId, NumberOfTravellers);

                    //Hardcoded text, better with resx translations
                    //await
                    //    _dialogService.ShowAlertAsync("This journey is now in your Saved Journeys!", "My Trains says...", "OK");

                    await
                        _dialogService.ShowAlertAsync
                        (TextSource.GetText("AddedToSavedJourneysMessage"), 
                         TextSource.GetText("AddedToSavedJourneysTitle"), 
                         TextSource.GetText("AddedToSavedJourneysButton"));
                });
            }
        }

        public MvxCommand CloseCommand
        { get { return new MvxCommand(() => Close(this)); } }

        public Journey SelectedJourney
        {
            get { return _selectedJourney; }
            set
            {
                _selectedJourney = value;
                RaisePropertyChanged(() => SelectedJourney);
            }
        }

        public int NumberOfTravellers
        {
            get { return _numberOfTravellers; }
            set
            {
                _numberOfTravellers = value;
                RaisePropertyChanged(() => NumberOfTravellers);
            }
        }

        public JourneyDetailViewModel(IMvxMessenger messenger, 
            IJourneyDataService journeyDataService,
            ISavedJourneyDataService savedJourneyDataService,
            IDialogService dialogService, 
            IUserDataService userDataService) : base(messenger)
        {
            _journeyDataService = journeyDataService;
            _savedJourneyDataService = savedJourneyDataService;
            _dialogService = dialogService;
            _userDataService = userDataService;
        }

        public void Init(int journeyId)
        {
            _journeyId = journeyId;
        }

        public override async void Start()
        {
            base.Start();
            await ReloadDataAsync();
        }

        protected override async Task InitializeAsync()
        {
            SelectedJourney = await _journeyDataService.GetJourneyDetails(_journeyId);
        }

        public class SavedState
        {
            public int JourneyId { get; set; }
        }

        public SavedState SaveState()
        {
            MvxTrace.Trace("SaveState called");
            return new SavedState { JourneyId = _journeyId };
        }

        public void ReloadState(SavedState savedState)
        {
            MvxTrace.Trace("ReloadState called with {0}", 
                savedState.JourneyId);
            _journeyId = savedState.JourneyId;
        }
    }
}