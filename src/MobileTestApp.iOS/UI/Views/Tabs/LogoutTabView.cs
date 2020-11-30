using MobileTestApp.Common;
using MobileTestApp.iOS.UI.Views.Abstract;
using MobileTestApp.ViewModels.Tabs;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using UIKit;

namespace MobileTestApp.iOS.UI.Views.Tabs
{
    [MvxTabPresentation(TabIconName = "ic_tab_logout", TabName = Constants.Tabs.Logout)]
    public partial class LogoutTabView : BaseView<LogoutTabViewModel>
    {
        public LogoutTabView() : base(nameof(LogoutTabView), null)
        {
        }

        protected override void Bind()
        {
            using var set = CreateBindingSet();
            
            set.Bind(LogoutButton).To(vm => vm.LogoutCommand);
            set.Bind(NavigationItem).For(v => v.Title).To(vm => vm.Title);
        }
    }
}