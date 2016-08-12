using System;
using MvvmCross.Binding.BindingContext;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.TableViewSources;
using UIKit;

namespace MyTrains.iOS.Views
{
    public partial class SearchResultView : BaseView
    {
        SearchResultsTableViewSource _searchResultsTableViewSource;

        public SearchResultView(IntPtr handle) : base(handle)
        {
            Title = "Search result";
        }

        protected SearchResultViewModel SearchResultViewModel 
            => ViewModel as SearchResultViewModel;

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        protected override void CreateBindings()
        {
            var set = 
                this.CreateBindingSet<SearchResultView, SearchResultViewModel>();

            set.Bind(_searchResultsTableViewSource).To(vm => vm.Journeys);
            set.Bind(_searchResultsTableViewSource)
                .For(source => source.SelectionChangedCommand)
                .To(vm => vm.ShowJourneyDetailsCommand);

            set.Apply();
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            _searchResultsTableViewSource = 
                new SearchResultsTableViewSource(searchResultsTableView);

            base.ViewDidLoad();

            searchResultsTableView.Source = _searchResultsTableViewSource;
            searchResultsTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            SearchResultViewModel.ReloadDataCommand.Execute();
            searchResultsTableView.DeselectRow(searchResultsTableView.IndexPathForSelectedRow, true);
        }

        #endregion
    }
}