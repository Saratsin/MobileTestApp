using MobileTestApp.Common.Extensions;
using MobileTestApp.Messages;
using MobileTestApp.Models;
using MobileTestApp.ViewModels.Abstract;
using MobileTestApp.ViewModels.Tabs;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace MobileTestApp.ViewModels
{
    public class MainViewModel : BaseViewModel, IMvxViewModel<User>
    {
        private User _user;

        public void Prepare(User parameter)
        {
            _user = parameter;
        }

        public Task ShowTabViewModelsAsync()
        {
            return Task.WhenAll(NavigationService.Navigate<OverviewTabViewModel, User>(_user),
                                NavigationService.Navigate<EditTabViewModel, User>(_user),
                                NavigationService.Navigate<LogoutTabViewModel, User>(_user));
        }
    }
}