using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MyTrains.iOS
{
    public class StoryBoardContainer: MvxIosViewsContainer
    {
        protected override IMvxIosView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            return (IMvxIosView)UIStoryboard.FromName("Storyboard", null)
                 .InstantiateViewController(viewType.Name);
        }
    }
}