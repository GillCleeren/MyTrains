
using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MyTrains.Core.ViewModel;
using MyTrains.iOS.Utility;
using UIKit;

namespace MyTrains.iOS.Views
{
    public partial class MainView : MvxTabBarViewController<MainViewModel>
    {
        private int _tabsCreatedSoFar;

        public MainView(IntPtr handle) : base(handle)
        {
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
            base.ViewDidLoad();

            CreateTabs();
        }

        public override void ItemSelected(UITabBar tabbar, UITabBarItem item)
        {
            Title = item.Title;
        }

        private void CreateTabs()
        {
            var viewControllers = new UIViewController[]
            {
                CreateTab("Search", "ic-search-", ViewModel.SearchJourneyViewModel),
                CreateTab("Saved journeys", "ic-saved-", ViewModel.SavedJourneysViewModel),
                CreateTab("Settings", "ic-settings-", ViewModel.SettingsViewModel)
            };

            ViewControllers = viewControllers;

            SelectedViewController = ViewControllers[0];
            Title = SelectedViewController.Title;

            NavigationItem.Title = SelectedViewController.Title;
            
            ViewControllerSelected += (o, e) =>
            {
                NavigationItem.Title = TabBar.SelectedItem.Title;
            };
        }

        private UIViewController CreateTab
            (string title, string imageName, IMvxViewModel viewModel)
        {
            var viewController = 
                this.CreateViewControllerFor(viewModel) as UIViewController;
            viewModel.Start();

            UpdateTabBar(viewController, title, imageName);

            return viewController;
        }

        private void UpdateTabBar(UIViewController viewController, string title, string imageName)
        {
            viewController.Title = title;

            viewController.TabBarItem = new UITabBarItem(
                title,
                UIImage.FromBundle(imageName + "normal.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                _tabsCreatedSoFar)
            {
                SelectedImage = UIImage.FromBundle(imageName + "active.png")
                    .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal)
            };

            var font = UIFont.FromName("Helvetica", 10);

            viewController.TabBarItem.SetTitleTextAttributes(
                new UITextAttributes { TextColor = MyTrainsColors.DarkTextColor, Font = font },
                UIControlState.Normal);

            viewController.TabBarItem.SetTitleTextAttributes(
                new UITextAttributes { TextColor = MyTrainsColors.AccentColor, Font = font },
                UIControlState.Selected);

            _tabsCreatedSoFar++;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
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