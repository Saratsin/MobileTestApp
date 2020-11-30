using MobileTestApp.Factories.Commands;
using MobileTestApp.Managers.Notes;
using MobileTestApp.Managers.Users;
using MobileTestApp.Repositories.Notes;
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
            provider.LazyConstructAndRegisterSingleton<INotesRepository, NotesRepository>();

            provider.LazyConstructAndRegisterSingleton<IUsersManager, UsersManager>();
            provider.LazyConstructAndRegisterSingleton<INotesManager, NotesManager>();

            RegisterAppStart<LoginViewModel>();
        }
    }
}