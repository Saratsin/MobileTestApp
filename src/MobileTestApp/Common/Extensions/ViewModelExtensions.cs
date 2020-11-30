using MobileTestApp.Factories.Commands;
using MobileTestApp.ViewModels.Abstract;
using MvvmCross;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTestApp.Common.Extensions
{
    public static class ViewModelExtensions
    {
        private static readonly Lazy<ICommandsFactory> _commandsFactoryLazy = new Lazy<ICommandsFactory>(Mvx.IoCProvider.Resolve<ICommandsFactory>);

        private static ICommandsFactory CommandsFactory => _commandsFactoryLazy.Value;

        public static ICommand CreateCommand(this BaseViewModel viewModel,
                                             Func<Task> execute,
                                             bool notifyIsBusyChanged = true)
        {
            return CommandsFactory.Create(viewModel, execute, null, notifyIsBusyChanged);
        }

        public static ICommand CreateCommand(this BaseViewModel viewModel,
                                             Func<Task> execute,
                                             Func<bool> canExecute,
                                             bool notifyIsBusyChanged = true)
        {
            return CommandsFactory.Create(viewModel, execute, canExecute, notifyIsBusyChanged);
        }

        public static ICommand CreateCommand<TParameter>(this BaseViewModel viewModel,
                                                         Func<TParameter, Task> execute,
                                                         bool notifyIsBusyChanged = true)
        {
            return CommandsFactory.Create(viewModel, execute, null, notifyIsBusyChanged);
        }

        public static ICommand CreateCommand<TParameter>(this BaseViewModel viewModel,
                                                         Func<TParameter, Task> execute,
                                                         Func<TParameter, bool> canExecute,
                                                         bool notifyIsBusyChanged = true)
        {
            return CommandsFactory.Create(viewModel, execute, canExecute, notifyIsBusyChanged);
        }
    }
}
