using System;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ProductManagement.Products;

public class ProductRepository : EfCoreRepository<ProductManagementDbContext, Product, Guid>, IProductRepository
{
    public ProductRepository(IDbContextProvider<ProductManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Product>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}