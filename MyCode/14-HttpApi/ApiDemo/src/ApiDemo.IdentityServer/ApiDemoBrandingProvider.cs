using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ApiDemo;

[Dependency(ReplaceServices = true)]
public class ApiDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ApiDemo";
}
