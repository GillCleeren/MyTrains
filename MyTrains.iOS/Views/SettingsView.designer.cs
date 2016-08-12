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
	[Register ("SettingsView")]
	partial class SettingsView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView AboutTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CurrencyTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView testTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton VisitSiteButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AboutTextView != null) {
				AboutTextView.Dispose ();
				AboutTextView = null;
			}
			if (CurrencyTextField != null) {
				CurrencyTextField.Dispose ();
				CurrencyTextField = null;
			}
			if (testTextView != null) {
				testTextView.Dispose ();
				testTextView = null;
			}
			if (VisitSiteButton != null) {
				VisitSiteButton.Dispose ();
				VisitSiteButton = null;
			}
		}
	}
}
