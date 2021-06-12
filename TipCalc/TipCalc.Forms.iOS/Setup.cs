using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Ios.Core;
using Serilog;
using Serilog.Extensions.Logging;
using TipCalc.Core;
using TipCalc.Forms.UI;

namespace TipCalc.Forms.iOS
{
    public class Setup : MvxFormsIosSetup<App, FormsApp>
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
                .WriteTo.NSLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}
