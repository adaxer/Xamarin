using Foundation;
using MvvmCross.Platforms.Ios.Core;
using HelloCross.Core;

namespace HelloCross.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
