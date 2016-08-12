using System;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MyTrains.iOS.TableViewSources
{
    public class SavedJourneysTableViewSource: MvxTableViewSource
    {
        public SavedJourneysTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        public SavedJourneysTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ItemsSource.Count();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (SavedJourneyCell)tableView.DequeueReusableCell(SavedJourneyCell.Identifier);
            return cell;
        }
    }
}