using Acme.BookStore;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpConsoleService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookStoreHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
)]
public class AppModule : AbpModule
{
    
}