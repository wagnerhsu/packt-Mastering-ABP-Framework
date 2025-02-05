using Acme.BookStore.Books;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AbpConsoleService;

public class AbpHostedService : BackgroundService
{
    private readonly ILogger<AbpHostedService> _logger;
    private readonly IBookAppService _bookAppService;

    public AbpHostedService(ILogger<AbpHostedService> logger, IBookAppService bookAppService)
    {
        _logger = logger;
        _bookAppService = bookAppService;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var listOfBooks = await _bookAppService.GetListAsync();
        _logger.LogInformation($"Books: {string.Join(", ", listOfBooks.Items.Select(p => p.Name).ToList())}");
    }
}