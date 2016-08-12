using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MyTrains.Core;
using MyTrains.Core.Contracts.Services;
using MyTrains.iOS.Services;
using UIKit;

namespace MyTrains.iOS
{
    public class Setup: MvxIosSetup
    {
        private MvxApplicationDelegate _applicationDelegate;
        UIWindow _window;

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
            _applicationDelegate = applicationDelegate;
            _window = window;
        }

        public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
        }

        protected override IMvxIosViewsContainer CreateIosViewsContainer()
        {
            return new StoryBoardContainer();
        }
    }
}