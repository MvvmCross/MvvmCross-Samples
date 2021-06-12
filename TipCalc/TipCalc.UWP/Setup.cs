using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Uap.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace TipCalc.UWP
{
    public class Setup : MvxWindowsSetup<Core.App>
    {
        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            // serilog configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}