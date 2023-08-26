using System.Globalization;
using Core;
using Microsoft.Extensions.Logging;
using MvvmCross.Binding;
using MvvmCross.Platforms.Ios.Core;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;

namespace iOSApp;

public class Setup : MvxIosSetup<App>
{
    protected override ILoggerProvider? CreateLogProvider() => new SerilogLoggerProvider();

    protected override ILoggerFactory? CreateLogFactory()
    {
#if DEBUG
        MvxBindingLog.TraceBindingLevel = LogLevel.Information;
#endif

        var logFolder = GetLogFolder();
        var logger = LoggingSetup.CreateCommonLoggerConfiguration(logFolder)
            .WriteTo.Async(l => l.NSLog(
                LogEventLevel.Verbose,
                LoggingSetup.OutputTemplate,
                CultureInfo.InvariantCulture
            ))
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