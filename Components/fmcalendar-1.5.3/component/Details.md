FMCalendar control is a calendar view for your iPhone or iPad app.

It can be easily added to your iOS app, and allows you to customize it's appearance and to handle it's events.

All the day and month names are automatically localized, based on the system language.

Here is an example on how it works:

```csharp
using Factorymind.Components;
...

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
		return date.Day % 2 == 1;
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
```

Inspired by Eduardo Scoz https://github.com/escoz