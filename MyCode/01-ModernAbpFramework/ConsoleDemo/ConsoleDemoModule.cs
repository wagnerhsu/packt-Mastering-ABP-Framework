using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ConsoleDemo
{
    [DependsOn(typeof(AbpAutofacModule))]
    public class ConsoleDemoModule : AbpModule
    {
        public override Task OnApplicationInitializationAsync(
            ApplicationInitializationContext context
        )
        {
            var logger = context.ServiceProvider.GetRequiredService<ILogger<ConsoleDemoModule>>();
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            logger.LogInformation($"MySettingName => {configuration["MySettingName"]}");

            var hostEnvironment = context.ServiceProvider.GetRequiredService<IHostEnvironment>();
               logger.LogInformation($"EnvironmentName => {hostEnvironment.EnvironmentName}");
            return base.OnApplicationInitializationAsync(context);
        }
    }
}
