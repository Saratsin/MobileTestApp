using MobileTestApp.ViewModels.Abstract;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTestApp.Factories.Commands
{
    public interface ICommandsFactory
    {
        ICommand Create(BaseViewModel viewModel,
                        Func<Task> execute,
                        Func<bool> canExecute = null,
                        bool notifyIsBusyChanged = true);

        ICommand Create<TParameter>(BaseViewModel viewModel,
                                    Func<TParameter, Task> execute,
                                    Func<TParameter, bool> canExecute = null,
                                    bool notifyIsBusyChanged = true);
    }
}