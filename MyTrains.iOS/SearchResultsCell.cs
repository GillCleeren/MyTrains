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
	public partial class SearchResultsCell : MvxTableViewCell
	{
        internal static readonly NSString Identifier = 
            new NSString("SearchResultsCell");

        public SearchResultsCell(IntPtr handle) : base(handle)
        {
        }

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<SearchResultsCell, Journey>();

            set.Bind(fromCityLabel)
                .To(vm => vm.FromCity.CityName);

            set.Bind(toCityLabel)
                .To(vm => vm.ToCity.CityName);

            set.Bind(departureDateLabel)
                .To(vm => vm.JourneyDate)
                .WithConversion(new DateTimeToDayConverter());

            set.Bind(departureTimeLabel)
                .To(vm => vm.DepartureTime)
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
