
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Localization;
using MyTrains.Core.Converters;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.Utility;

namespace MyTrains.iOS.Views
{
    public partial class JourneyDetailView : BaseView
    {
        protected JourneyDetailViewModel JourneyDetailViewModel 
            => ViewModel as JourneyDetailViewModel;

        public JourneyDetailView(IntPtr handle) : base(handle)
        {
            Title = "Journey details";
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = 
                this.CreateBindingSet<JourneyDetailView, JourneyDetailViewModel>();

            set.Bind(DepartureDateLabel)
                .To(vm => vm.SelectedJourney.JourneyDate)
                .WithConversion(new DateTimeToDayConverter());

            set.Bind(FromCityLabel).To(vm => vm.SelectedJourney.FromCity);
            set.Bind(ToCityLabel).To(vm => vm.SelectedJourney.ToCity);
            set.Bind(DepartureTimeLabel)
                .To(vm => vm.SelectedJourney.DepartureTime)
                .WithConversion(new DateTimeToTimeConverter());
            set.Bind(ArrivalTimeLabel)
                .To(vm => vm.SelectedJourney.ArrivalTime)
                .WithConversion(new DateTimeToTimeConverter());
            set.Bind(PriceLabel)
                .To(vm => vm.SelectedJourney.Price)
                .WithConversion(new CurrencyToStringConverter());

            //Translations
            set.Bind(JourneyDetailsViewTitle).To(vm => vm.TextSource)
                .WithConversion(new MvxLanguageConverter(), 
                    "JourneyDetailTitleTextView");

            set.Bind(NumberOfTicketsTextField)
                .To(vm => vm.NumberOfTravellers).TwoWay();

            set.Bind(AddToSavedJourneysButton).
                To(vm => vm.AddToSavedJourneysCommand);
            set.Bind(CloseButton).To(vm => vm.CloseCommand);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CloseButton.Layer.BorderWidth = 1;
            CloseButton.Layer.BorderColor = MyTrainsColors.AccentColor.CGColor;

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}