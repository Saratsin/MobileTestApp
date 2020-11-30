using System;
using System.Reactive.Disposables;

namespace MobileTestApp.Common.Extensions
{
    public static class DisposableExtensions
    {
        public static TDisposable DisposeWith<TDisposable>(this TDisposable disposable, CompositeDisposable disposables)
            where TDisposable : class, IDisposable
        {
            disposables.Add(disposable);
            return disposable;
        }
    }
}