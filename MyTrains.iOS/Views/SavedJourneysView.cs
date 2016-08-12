
using System;
using System.Drawing;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.TableViewSources;
using UIKit;

namespace MyTrains.iOS.Views
{
    public partial class SavedJourneysView : BaseView
    {
        private SavedJourneysTableViewSource _savedJourneysTableViewSource;

        protected SavedJourneysViewModel SavedJourneysViewModel => ViewModel as SavedJourneysViewModel;

        public SavedJourneysView(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = this.CreateBindingSet<SavedJourneysView, SavedJourneysViewModel>();

            set.Bind(_savedJourneysTableViewSource).To(vm => vm.SavedJourneys);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            _savedJourneysTableViewSource = new SavedJourneysTableViewSource(savedJourneyTableView);

            base.ViewDidLoad();

            savedJourneyTableView.Source = _savedJourneysTableViewSource;
            //savedJourneyTableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
            //savedJourneyTableView.SeparatorColor = UIColor.FromRGB(0, 215, 203);
            savedJourneyTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            SavedJourneysViewModel.ReloadDataCommand.Execute();

            //savedJourneyTableView.DeselectRow(savedJourneyTableView.IndexPathForSelectedRow, true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}