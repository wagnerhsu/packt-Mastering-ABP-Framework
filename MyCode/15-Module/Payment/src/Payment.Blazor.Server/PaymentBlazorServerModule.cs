using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Payment.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(PaymentBlazorModule)
    )]
public class PaymentBlazorServerModule : AbpModule
{

}
