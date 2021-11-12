using Microsoft.Extensions.Logging;
using MvvmCross;

namespace StarWarsSample.Core
{
    public static class Logs
    {
        public static ILogger Instance { get; } = Mvx.IoCProvider.Resolve<ILoggerProvider>().CreateLogger("StarWarsSample");
    }
}
