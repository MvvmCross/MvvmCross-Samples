using System.Globalization;
using Core;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding;
using MvvmCross.Platforms.Android.Core;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Compact;

namespace AndroidApp;

public class Setup : MvxAndroidSetup<App>
{
    protected override ILoggerProvider? CreateLogProvider() => new SerilogLoggerProvider();

    protected override ILoggerFactory? CreateLogFactory()
    {
        const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {SourceContext:l}:#{ThreadId} [{Level}] {Message}{NewLine}{Exception}";
        
#if DEBUG
        MvxBindingLog.TraceBindingLevel = LogLevel.Information;
#endif
        var logFolder = GetLogFolder();
        var logger = new LoggerConfiguration()
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
            ))
            .WriteTo.Async(l => l.AndroidLog(
                LogEventLevel.Verbose,
                outputTemplate,
                CultureInfo.InvariantCulture
            ))
#if DEBUG
            .WriteTo.Async(l => l.Trace(outputTemplate: outputTemplate, formatProvider: CultureInfo.InvariantCulture))
#endif
            .CreateLogger();
        
        logger.Information("------------------AppStart-----------------");
        logger.Information("Find logs in: {LogFolder}", logFolder);
        
        return new SerilogLoggerFactory();
    }
    
    private static string GetLogFolder()
    {
        var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var logFolder = Path.Combine(documents, "Logs");

        return logFolder;
    }
}