using MyTrains.Core.Contracts.Services;
using Plugin.Connectivity;

namespace MyTrains.Core.Services.General
{
    public class ConnectionService : IConnectionService
    {
        public bool CheckOnline()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
