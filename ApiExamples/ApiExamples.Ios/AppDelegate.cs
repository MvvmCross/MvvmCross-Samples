using ApiExamples.Core;
using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace ApiExamples.Ios
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}