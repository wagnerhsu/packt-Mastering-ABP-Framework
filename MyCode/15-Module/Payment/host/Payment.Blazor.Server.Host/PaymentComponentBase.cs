using Payment.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Payment.Blazor.Server.Host;

public abstract class PaymentComponentBase : AbpComponentBase
{
    protected PaymentComponentBase()
    {
        LocalizationResource = typeof(PaymentResource);
    }
}
