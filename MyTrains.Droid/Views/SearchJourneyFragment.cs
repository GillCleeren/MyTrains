using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using MyTrains.Core.ViewModel;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MyTrains.Droid.Activities;
using MyTrains.Droid.Extensions;
using Square.TimesSquare;

namespace MyTrains.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("mytrains.droid.views.SearchJourneyFragment")]
    public class SearchJourneyFragment : MvxFragment<SearchJourneyViewModel>
    {
        private DateTime _currentDate;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.SearchJourneyView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("Search journeys");
        }

        public override void OnStart()
        {
            base.OnStart();

            SetupCalendar();
        }

        private void SetupCalendar()
        {
            _currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var calendar = View.FindViewById<CalendarPickerView>(Resource.Id.calendar);
            calendar.VerticalScrollBarEnabled = false;
            calendar.SmoothScrollbarEnabled = false;

            SetupCalendar(calendar, 0).WithSelectedDate(_currentDate);

            calendar.DateSelected += (date, e) =>
            {
                ViewModel.SelectedDate = e.Date.ToUniversalTime();
            };

            var leftButton = View.FindViewById<ImageButton>(Resource.Id.buttonLeft);
            var rightButton = View.FindViewById<ImageButton>(Resource.Id.buttonRight);

            leftButton.Click += (sender, e) => { SetupCalendar(calendar, -1); };
            rightButton.Click += (sender, e) => { SetupCalendar(calendar, 1); };
        }

        private CalendarPickerView.FluentInitializer SetupCalendar(CalendarPickerView calendar, int diffMonths)
        {
            _currentDate = new DateTime(_currentDate.Year, _currentDate.Month, 1).AddMonths(diffMonths);

            var isCurrentMonth = _currentDate.Year == DateTime.Now.Year && _currentDate.Month == DateTime.Now.Month;
            if (isCurrentMonth) { _currentDate = DateTime.Now; }

            var lastDay = new DateTime(_currentDate.Year, _currentDate.Month, 1).AddMonths(1);

            return calendar.Init(_currentDate, lastDay);
        }
    }
}