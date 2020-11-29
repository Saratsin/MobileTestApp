using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace MobileTestApp.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
