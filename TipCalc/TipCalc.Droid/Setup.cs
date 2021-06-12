using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using Serilog;
using Serilog.Extensions.Logging;
using TipCalc.Core;

namespace TipCalc.UI.Droid
{
    public class Setup : MvxAndroidSetup<App>
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
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}
