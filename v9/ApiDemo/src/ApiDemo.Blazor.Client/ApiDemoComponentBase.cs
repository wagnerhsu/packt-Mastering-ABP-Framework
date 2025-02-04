using ApiDemo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ApiDemo.Blazor.Client;

public abstract class ApiDemoComponentBase : AbpComponentBase
{
    protected ApiDemoComponentBase()
    {
        LocalizationResource = typeof(ApiDemoResource);
    }
}
