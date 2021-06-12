using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;
using Serilog;
using Serilog.Extensions.Logging;
using TipCalc.Core;
using TipCalc.Forms.UI;

namespace TipCalc.Forms.Droid
{
    public class Setup : MvxFormsAndroidSetup<App, FormsApp>
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
