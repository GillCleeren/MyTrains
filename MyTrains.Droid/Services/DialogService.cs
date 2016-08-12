using System.Threading.Tasks;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MyTrains.Core.Contracts.Services;

namespace MyTrains.Droid.Services
{
    public class DialogService: IDialogService
    {
        protected Activity CurrentActivity => 
            Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        public Task ShowAlertAsync(string message, 
            string title, string buttonText)
        {
            return Task.Run(() =>
            {
                Alert(message, title, buttonText);
            });
        }

        private void Alert(string message, string title, string okButton)
        {
            Application.SynchronizationContext.Post(ignored =>
            {
                var builder = new AlertDialog.Builder(CurrentActivity);
                builder.SetIconAttribute
                    (Android.Resource.Attribute.AlertDialogIcon);
                builder.SetTitle(title);
                builder.SetMessage(message);
                builder.SetPositiveButton(okButton, delegate { });
                builder.Create().Show();
            }, null);
        }
    }
}