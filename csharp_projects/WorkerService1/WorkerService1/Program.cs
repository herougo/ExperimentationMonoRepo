using CliWrap;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using Serilog;
using WorkerService1;

const string ServiceName = ".NET Joke Service";

if (args is { Length: 1 })
{
    try
    {
        string executablePath =
            Path.Combine(AppContext.BaseDirectory, "WorkerService1.exe");

        if (args[0] is "/Install")
        {
            await Cli.Wrap("sc")
                .WithArguments(new[] { "create", ServiceName, $"binPath={executablePath}", "start=auto" })
                .ExecuteAsync();
        }
        else if (args[0] is "/Uninstall")
        {
            await Cli.Wrap("sc")
                .WithArguments(new[] { "stop", ServiceName })
                .ExecuteAsync();

            await Cli.Wrap("sc")
                .WithArguments(new[] { "delete", ServiceName })
                .ExecuteAsync();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }

    return;
}

string logPath = Path.Combine(AppContext.BaseDirectory, "logs/myapp.txt");
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

try
{
    Log.Information("Starting up...");
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(Log.Logger);
    builder.Services.AddWindowsService(options =>
    {
        options.ServiceName = ".NET Joke Service";
    });

    // LoggerProviderOptions.RegisterProviderOptions<
    //     EventLogSettings, EventLogLoggerProvider>(builder.Services);

    builder.Services.AddSingleton<JokeService>();
    builder.Services.AddHostedService<WindowsBackgroundService>();

    IHost host = builder.Build();
    host.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}