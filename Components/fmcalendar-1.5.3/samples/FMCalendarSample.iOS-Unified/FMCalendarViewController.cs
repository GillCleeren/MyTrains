using System;
using Factorymind.Components;
using UIKit;

namespace FMCalendarSample.iOS
{
	public class FMCalendarViewController : UIViewController
	{
		private FMCalendar fmCalendar;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			fmCalendar = new FMCalendar (View.Bounds);

			View.BackgroundColor = UIColor.White;

			// Specify selection color
			fmCalendar.SelectionColor = UIColor.Red;

			// Specify today circle Color
			fmCalendar.TodayCircleColor = UIColor.Red;

			// Customizing appearance
			fmCalendar.LeftArrow = UIImage.FromFile ("leftArrow.png");
			fmCalendar.RightArrow = UIImage.FromFile ("rightArrow.png");

			fmCalendar.MonthFormatString = "MMMM yyyy";

			// Shows Sunday as last day of the week
			fmCalendar.SundayFirst = false;

			// Mark with a dot dates that fulfill the predicate
			fmCalendar.IsDayMarkedDelegate = (date) => 
			{
				return date.Day % 2 == 0;
			};

			// Turn gray dates that fulfill the predicate
			fmCalendar.IsDateAvailable = (date) =>
			{
				return (date >= DateTime.Today);
			};

			fmCalendar.MonthChanged = (date) => 
			{
				Console.WriteLine ("Month changed {0}", date.Date);
			};

			fmCalendar.DateSelected += (date) => 
			{
				Console.WriteLine ("Date selected: {0}", date);
			};

			// Add FMCalendar to SuperView
			fmCalendar.Center = this.View.Center;
			this.View.AddSubview (fmCalendar);
		}

		public override bool PrefersStatusBarHidden ()
		{
			return true;
		}
	}
}