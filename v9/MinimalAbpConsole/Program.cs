using Acme.BookStore.Books;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MinimalAbpConsole;
using Volo.Abp;
using Serilog.Events;
using Serilog;

Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();
using var application = AbpApplicationFactory.Create<AppModule>(options =>
            {
                options.UseAutofac();
            });

await application.InitializeAsync();

var bookAppService = application.ServiceProvider.GetService<IBookAppService>();
var loggerFactory = application.ServiceProvider.GetService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger(nameof(Program));
var listOfBooks = await bookAppService.GetListAsync();
logger.LogInformation($"Books: {string.Join(", ", listOfBooks.Items.Select(p => p.Name).ToList())}");

await application.ShutdownAsync();

