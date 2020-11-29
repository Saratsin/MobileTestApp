using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace MobileTestApp.Wrappers
{
    public class IsBusyWrapper : MvxNotifyPropertyChanged
    {
        public bool IsBusy { get; private set; }

        public async Task WrapAsync(Action action, bool notifyIsBusyChanged = true)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                await SetIsBusyAsync(true, notifyIsBusyChanged).ConfigureAwait(false);
                action.Invoke();
            }
            finally
            {
                await SetIsBusyAsync(false, notifyIsBusyChanged).ConfigureAwait(false);
            }
        }

        public async Task WrapAsync(Func<Task> func, bool notifyIsBusyChanged = true)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                await SetIsBusyAsync(true, notifyIsBusyChanged).ConfigureAwait(false);
                await func.Invoke().ConfigureAwait(false);
            }
            finally
            {
                await SetIsBusyAsync(false, notifyIsBusyChanged).ConfigureAwait(false);
            }
        }

        private async ValueTask SetIsBusyAsync(bool isBusy, bool notifyIsBusyChanged)
        {
            if (IsBusy == isBusy)
            {
                return;
            }

            IsBusy = isBusy;
            if (!notifyIsBusyChanged)
            {
                return;
            }

            await  RaisePropertyChanged(nameof(IsBusy)).ConfigureAwait(false);
        }
    }
}