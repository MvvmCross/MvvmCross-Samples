using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Mac.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace TipCalc.UI.Mac
{
    public class Setup : MvxMacSetup<Core.App>
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

