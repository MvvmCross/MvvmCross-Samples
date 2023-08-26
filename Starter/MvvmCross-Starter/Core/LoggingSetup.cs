using System.Globalization;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace Core;

public static class LoggingSetup
{
    public const string OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {SourceContext:l}:#{ThreadId} [{Level}] {Message}{NewLine}{Exception}";
    
    public static LoggerConfiguration CreateCommonLoggerConfiguration(string logFolder)
    {
        var loggerConfig =
            new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                .MinimumLevel.Override("System", LogEventLevel.Verbose)
                .MinimumLevel.Override("Xamarin", LogEventLevel.Verbose)
                .WriteTo.Async(a => a.File(
                    new CompactJsonFormatter(),
                    Path.Combine(logFolder, "logs.clef"),
                    LogEventLevel.Verbose,
                    10_000_000, // ~10 MB
                    rollingInterval: RollingInterval.Day
                ));
#if DEBUG
        loggerConfig = loggerConfig.WriteTo.Async(l =>
            l.Trace(outputTemplate: OutputTemplate, formatProvider: CultureInfo.InvariantCulture));
#endif

        return loggerConfig;
    }
}