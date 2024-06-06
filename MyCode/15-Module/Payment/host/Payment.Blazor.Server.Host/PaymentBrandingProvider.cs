using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Payment.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class PaymentBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Payment";
}
