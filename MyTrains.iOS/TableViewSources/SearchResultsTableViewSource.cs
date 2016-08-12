using System;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MyTrains.iOS.TableViewSources
{
    public class SearchResultsTableViewSource: MvxTableViewSource
    {
        public SearchResultsTableViewSource(UITableView tableView) : 
            base(tableView)
        {
        }

        public SearchResultsTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ItemsSource.Count();
        }

        protected override UITableViewCell GetOrCreateCellFor
            (UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (SearchResultsCell)
                tableView.DequeueReusableCell(SearchResultsCell.Identifier);
            return cell;
        }

        protected override object GetItemAt(NSIndexPath indexPath)
        {
            return ItemsSource?.ElementAt(indexPath.Row);
        }
    }
}