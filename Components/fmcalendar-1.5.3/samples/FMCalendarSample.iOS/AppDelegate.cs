using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FMCalendarSample.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		
		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// We create a FlyoutNavigationController to be the 'root' of our app
			var controller = new FMCalendarViewController ();

			Window = new UIWindow (UIScreen.MainScreen.Bounds);
			Window.MakeKeyAndVisible ();
			Window.RootViewController = controller;
			return true;
		}
	}
}