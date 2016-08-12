using MyTrains.Core.ViewModel;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using MyTrains.Core.Contracts.Services;

namespace MyTrains.Core.Fake
{
    public class FakeSearchJourneyViewModel : SearchJourneyViewModel
    {
        public FakeSearchJourneyViewModel(IMvxMessenger messenger, ICityDataService cityDataService, IConnectionService connectionService, IDialogService dialogService) : base(messenger, cityDataService, connectionService, dialogService)
        {
        }

        public new Task InitializeAsync()
        {
            return base.InitializeAsync();
        }
    }
}
