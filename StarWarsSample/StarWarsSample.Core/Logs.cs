using MvvmCross;
using MvvmCross.Logging;

namespace StarWarsSample.Core
{
    public static class Logs
    {
        public static IMvxLog Instance { get; } = Mvx.IoCProvider.Resolve<IMvxLogProvider>().GetLogFor("StarWarsSample");
    }
}
