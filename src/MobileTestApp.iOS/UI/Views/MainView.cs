using MobileTestApp.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;

namespace MobileTestApp.iOS.UI.Views
{
    [MvxRootPresentation]
    public class MainView : MvxTabBarViewController<MainViewModel>
    {
        private bool _isFirstAppearing = true;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (ViewModel is null || !_isFirstAppearing)
            {
                return;
            }

            _isFirstAppearing = false;
            _ = ViewModel.ShowTabViewModelsAsync();
        }
    }
}