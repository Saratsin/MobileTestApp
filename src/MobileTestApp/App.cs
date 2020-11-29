using MobileTestApp.Facories.Commands;
using MobileTestApp.Repositories.Users;
using MobileTestApp.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace MobileTestApp
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var provider = Mvx.IoCProvider;

            provider.LazyConstructAndRegisterSingleton<ICommandsFactory, CommandsFactory>();
            provider.LazyConstructAndRegisterSingleton<IUsersRepository, UsersRepository>();
            
            RegisterAppStart<LoginViewModel>();
        }
    }
}