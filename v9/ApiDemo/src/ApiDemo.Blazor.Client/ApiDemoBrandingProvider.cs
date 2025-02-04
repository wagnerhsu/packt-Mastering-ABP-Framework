using Microsoft.Extensions.Localization;
using ApiDemo.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ApiDemo.Blazor.Client;

[Dependency(ReplaceServices = true)]
public class ApiDemoBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ApiDemoResource> _localizer;

    public ApiDemoBrandingProvider(IStringLocalizer<ApiDemoResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
