using ConsoleDemo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Volo.Abp;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(path: "serilog.json", optional: false, reloadOnChange: true)
    .Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
try
{
    using var application = await AbpApplicationFactory.CreateAsync<AppModule>(options =>
    {
        var builder = Host.CreateApplicationBuilder(args);
        options.Services.ReplaceConfiguration(builder.Configuration);
        options.Services.AddSingleton(builder.Environment);

        options.UseAutofac();
        options.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
    });

    await application.InitializeAsync();

    var loggerFactory = application.ServiceProvider.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger<Program>();
    var appConfiguration = application.ServiceProvider.GetRequiredService<IConfiguration>();
    logger.LogInformation($"Hello, World! {appConfiguration["MySettingName"]}");

    await application.ShutdownAsync();
    return 0;
}
catch (Exception ex)
{
    if (ex is HostAbortedException)
    {
        throw;
    }

    Log.Fatal(ex, "Host terminated unexpectedly!");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
