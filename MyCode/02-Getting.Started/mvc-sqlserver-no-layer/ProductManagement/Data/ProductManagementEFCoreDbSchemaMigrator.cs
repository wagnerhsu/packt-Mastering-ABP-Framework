using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace ProductManagement.Data;

public class ProductManagementEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public ProductManagementEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ProductManagementDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProductManagementDbContext>()
            .Database
            .MigrateAsync();
    }
}
