using Core;
using MvvmCross.Platforms.Ios.Core;

namespace iOSApp;

[Register("AppDelegate")]
public partial class AppDelegate : MvxApplicationDelegate<Setup, App>
{
}