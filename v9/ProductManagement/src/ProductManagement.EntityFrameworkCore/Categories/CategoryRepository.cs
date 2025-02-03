using System;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ProductManagement.Categories;

public class CategoryRepository : EfCoreRepository<ProductManagementDbContext, Category, Guid>, ICategoryRepository
{
    public CategoryRepository(IDbContextProvider<ProductManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Category>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}