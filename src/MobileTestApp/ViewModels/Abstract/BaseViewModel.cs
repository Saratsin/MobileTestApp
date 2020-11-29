using MobileTestApp.Wrappers;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MobileTestApp.ViewModels.Abstract
{
    public class BaseViewModel : MvxViewModel
    {
        public BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            IsBusyWrapper = new IsBusyWrapper();
            SafeWrapper = new SafeWrapper(OnExceptionHandledAsync);
        }

        public SafeWrapper SafeWrapper { get; }

        public IsBusyWrapper IsBusyWrapper { get; }

        protected IMvxNavigationService NavigationService { get; }

        protected virtual Task OnExceptionHandledAsync(Exception exception)
        {
            Debug.WriteLine(exception);
            return Task.CompletedTask;
        }
    }
}