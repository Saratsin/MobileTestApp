using MobileTestApp.Wrappers;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace MobileTestApp.ViewModels.Abstract
{
    public class BaseViewModel : MvxViewModel
    {
        public BaseViewModel()
        {
            SafeWrapper = new SafeWrapper(OnExceptionHandledAsync);
            IsBusyWrapper = new IsBusyWrapper();
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            Messenger = Mvx.IoCProvider.Resolve<IMvxMessenger>();
            Disposables = new CompositeDisposable();
        }

        public SafeWrapper SafeWrapper { get; }

        public IsBusyWrapper IsBusyWrapper { get; }

        protected IMvxNavigationService NavigationService { get; }

        protected IMvxMessenger Messenger { get; }

        protected CompositeDisposable Disposables { get; }

        public sealed override Task Initialize()
        {
            _ = SafeWrapper.WrapAsync(InitializeAsync);
            return Task.CompletedTask;
        }

        protected virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnExceptionHandledAsync(Exception exception)
        {
            Debug.WriteLine(exception);
            return Task.CompletedTask;
        }

        // NOTE It may not be called properly with some conditions (with and without WrapInNavigationPage property in MvxPresentation attributes for example)
        // It needs to be fixed manually inside presenter, otherwise it might call very rarely
        public override void ViewDestroy(bool viewFinishing = true)
        {
            Disposables.Dispose();
        }
    }
}