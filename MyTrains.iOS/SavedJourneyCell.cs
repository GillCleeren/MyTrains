using Foundation;
using System;
using System.CodeDom.Compiler;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MyTrains.Core.Converters;
using MyTrains.Core.Model;
using UIKit;

namespace MyTrains.iOS
{
	partial class SavedJourneyCell : MvxTableViewCell
    {
		public SavedJourneyCell (IntPtr handle) : base (handle)
		{
		}

	    internal static NSString Identifier = new NSString("SavedJourneyCell");

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<SavedJourneyCell, SavedJourney>();

            set.Bind(FromCityLabel)
                .To(vm => vm.Journey.FromCity.CityName);

            set.Bind(ToCityLabel)
                .To(vm => vm.Journey.ToCity.CityName);

            set.Bind(NumberOfTicketsLabel)
                .To(vm => vm.NumberOfTravellers);

            set.Bind(DepartureDateLabel)
                .To(vm => vm.Journey.JourneyDate)
                .WithConversion(new DateTimeToDayConverter());

            set.Bind(DepartureTimeLabel)
                .To(vm => vm.Journey.DepartureTime)
                .WithConversion(new DateTimeToTimeConverter());

            set.Apply();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CreateBindings();
        }
    }
}
