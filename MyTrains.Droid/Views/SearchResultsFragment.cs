using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MyTrains.Core.ViewModel;
using MyTrains.Droid.Activities;
using MyTrains.Droid.Extensions;

namespace MyTrains.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("mytrains.droid.views.SearchResultsFragment")]
    public class SearchResultsFragment: MvxFragment<SearchResultViewModel>
    {
        private bool _alreadyLoaded;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _alreadyLoaded = true;

            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.SearchResultsView, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            (this.Activity as MainActivity).SetCustomTitle("Search results");
        }

        public override void OnResume()
        {
            if(!_alreadyLoaded)ViewModel.Start();
            base.OnResume();
        }

        public override void OnStop()
        {
            _alreadyLoaded = false;
            base.OnStop();
        }
    }
}