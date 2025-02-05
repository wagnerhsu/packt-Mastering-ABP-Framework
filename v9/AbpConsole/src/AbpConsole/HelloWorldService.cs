using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;

namespace AbpConsole;

public class HelloWorldService : ITransientDependency
{
    private readonly IBookAppService _bookAppService;
    public ILogger<HelloWorldService> Logger { get; set; }

    public HelloWorldService(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
        Logger = NullLogger<HelloWorldService>.Instance;
    }

    public async Task SayHelloAsync()
    {
        Logger.LogInformation("Hello World!");
        var listOfBooks = await _bookAppService.GetListAsync();
        Logger.LogDebug($"Books: {string.Join(", ", listOfBooks.Items.Select(p => p.Name).ToList())}");
    }
}
