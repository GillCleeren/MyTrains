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

namespace MyTrains.iOS
{
	[Register ("SearchResultCell")]
	partial class SearchResultCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel departureDateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel departureTimeLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel fromCityLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel toCityLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (departureDateLabel != null) {
				departureDateLabel.Dispose ();
				departureDateLabel = null;
			}
			if (departureTimeLabel != null) {
				departureTimeLabel.Dispose ();
				departureTimeLabel = null;
			}
			if (fromCityLabel != null) {
				fromCityLabel.Dispose ();
				fromCityLabel = null;
			}
			if (toCityLabel != null) {
				toCityLabel.Dispose ();
				toCityLabel = null;
			}
		}
	}
}
