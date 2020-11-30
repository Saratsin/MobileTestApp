using MobileTestApp.Common.Extensions;
using MobileTestApp.Models;
using MobileTestApp.ViewModels.Abstract;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTestApp.ViewModels.Tabs
{
    public class LogoutTabViewModel : BaseViewModel, IMvxViewModel<User>
    {
        public LogoutTabViewModel()
        {
            LogoutCommand = this.CreateCommand(LogoutAsync);
        }

        public ICommand LogoutCommand { get; }

        private string _title;
        public string Title
        {
            get => _title;
            private set => SetProperty(ref _title, value);
        }

        public void Prepare(User parameter)
        {
            Title = parameter.Username;
        }

        private Task LogoutAsync()
        {
            return NavigationService.Navigate<LoginViewModel>();
        }
    }
}