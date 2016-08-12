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
	[Register ("SearchJourneyView")]
	partial class SearchJourneyView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView calendarContainerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField depatureTimeTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField fromCityTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton searchButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField toCityTextField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (calendarContainerView != null) {
				calendarContainerView.Dispose ();
				calendarContainerView = null;
			}
			if (depatureTimeTextField != null) {
				depatureTimeTextField.Dispose ();
				depatureTimeTextField = null;
			}
			if (fromCityTextField != null) {
				fromCityTextField.Dispose ();
				fromCityTextField = null;
			}
			if (searchButton != null) {
				searchButton.Dispose ();
				searchButton = null;
			}
			if (toCityTextField != null) {
				toCityTextField.Dispose ();
				toCityTextField = null;
			}
		}
	}
}
