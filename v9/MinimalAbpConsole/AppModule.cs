using Acme.BookStore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MinimalAbpConsole
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BookStoreHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
    )]
    public class AppModule: AbpModule
    {
         public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                    loggingBuilder.AddSerilog(dispose: true);
                }
            );
        }
    }
}