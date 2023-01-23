using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.WinUi.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace TipCalc.WinUI3
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
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}