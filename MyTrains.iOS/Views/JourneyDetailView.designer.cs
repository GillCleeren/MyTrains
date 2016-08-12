// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MyTrains.iOS.Views
{
	[Register ("JourneyDetailView")]
	partial class JourneyDetailView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton AddToSavedJourneysButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ArrivalTimeLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CloseButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DepartureDateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DepartureTimeLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel FromCityLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel JourneyDetailsViewTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField NumberOfTicketsTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PriceLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ToCityLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddToSavedJourneysButton != null) {
				AddToSavedJourneysButton.Dispose ();
				AddToSavedJourneysButton = null;
			}
			if (ArrivalTimeLabel != null) {
				ArrivalTimeLabel.Dispose ();
				ArrivalTimeLabel = null;
			}
			if (CloseButton != null) {
				CloseButton.Dispose ();
				CloseButton = null;
			}
			if (DepartureDateLabel != null) {
				DepartureDateLabel.Dispose ();
				DepartureDateLabel = null;
			}
			if (DepartureTimeLabel != null) {
				DepartureTimeLabel.Dispose ();
				DepartureTimeLabel = null;
			}
			if (FromCityLabel != null) {
				FromCityLabel.Dispose ();
				FromCityLabel = null;
			}
			if (JourneyDetailsViewTitle != null) {
				JourneyDetailsViewTitle.Dispose ();
				JourneyDetailsViewTitle = null;
			}
			if (NumberOfTicketsTextField != null) {
				NumberOfTicketsTextField.Dispose ();
				NumberOfTicketsTextField = null;
			}
			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}
			if (ToCityLabel != null) {
				ToCityLabel.Dispose ();
				ToCityLabel = null;
			}
		}
	}
}
