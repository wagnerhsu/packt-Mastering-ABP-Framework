using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace AbpConsole;

public class HelloWorldService : ITransientDependency
{
    private readonly ILogger<HelloWorldService> _logger;
    private readonly AzureSmsServiceOptions _options;

    public HelloWorldService(IOptions<AzureSmsServiceOptions> options, ILogger<HelloWorldService> logger)
    {
        _logger = logger;
        _options = options.Value;
    }

    public Task SayHelloAsync()
    {
        _logger.LogInformation($"Hello World! {_options.Sender}-{_options.ConnectionString}");
        return Task.CompletedTask;
    }
}
