using MobileTestApp.ViewModels.Abstract;
using MvvmCross.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTestApp.Factories.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        public ICommand Create(BaseViewModel viewModel,
                               Func<Task> execute,
                               Func<bool> canExecute = null,
                               bool notifyIsBusyChanged = true)
        {
            var wrappedExecute = WrapExecute(viewModel, execute, notifyIsBusyChanged);
            canExecute ??= () => true;

            return new MvxCommand(wrappedExecute, canExecute);
        }

        public ICommand Create<TParameter>(BaseViewModel viewModel,
                                           Func<TParameter, Task> execute,
                                           Func<TParameter, bool> canExecute = null,
                                           bool notifyIsBusyChanged = true)
        {
            var wrappedExecute = WrapExecute(viewModel, execute, notifyIsBusyChanged);
            canExecute ??= parameter => true;

            return new MvxCommand<TParameter>(wrappedExecute, canExecute);
        }

        private Action<TParameter> WrapExecute<TParameter>(BaseViewModel viewModel,
                                                           Func<TParameter, Task> execute,
                                                           bool notifyIsBusyChanged)
        {
            var isBusyReference = execute;
            execute = parameter => viewModel.IsBusyWrapper.WrapAsync(() => isBusyReference.Invoke(parameter), notifyIsBusyChanged);

            var safeExecutionReference = execute;
            execute = parameter => viewModel.SafeWrapper.WrapAsync(() => safeExecutionReference.Invoke(parameter));

            var wrappedExecute = new Action<TParameter>(parameter => _ = execute.Invoke(parameter));
            return wrappedExecute;
        }

        private Action WrapExecute(BaseViewModel viewModel,
                                   Func<Task> execute,
                                   bool notifyIsBusyChanged)
        {
            var isBusyReference = execute;
            execute = () => viewModel.IsBusyWrapper.WrapAsync(isBusyReference, notifyIsBusyChanged);

            var safeExecutionReference = execute;
            execute = () => viewModel.SafeWrapper.WrapAsync(safeExecutionReference);

            var wrappedExecute = new Action(() => _ = execute.Invoke());
            return wrappedExecute;
        }
    }
}