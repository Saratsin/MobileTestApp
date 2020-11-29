using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MobileTestApp.Wrappers
{
    public class SafeWrapper
    {
        public static SafeWrapper Default { get; } = new SafeWrapper();

        private readonly Func<Exception, Task> _exceptionHandler;

        public SafeWrapper(Func<Exception, Task> exceptionHandler = null)
        {
            _exceptionHandler = exceptionHandler;
        }

        public async Task WrapAsync(Func<Task> func)
        {
            try
            {
                await func.Invoke().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception).ConfigureAwait(false);
            }
        }

        public async Task WrapAsync(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionAsync(Exception exception)
        {
            if (_exceptionHandler is null)
            {
                Debug.WriteLine(exception);
                return Task.CompletedTask;
            }

            return _exceptionHandler.Invoke(exception);
        }
    }
}