using System;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.Permissions;
using ProductManagement.Categories.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Categories;

public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, CategoryGetListInput,
        CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
    ICategoryAppService
{
    protected override string GetPolicyName { get; set; } = ProductManagementPermissions.Category.Default;
    protected override string GetListPolicyName { get; set; } = ProductManagementPermissions.Category.Default;
    protected override string CreatePolicyName { get; set; } = ProductManagementPermissions.Category.Create;
    protected override string UpdatePolicyName { get; set; } = ProductManagementPermissions.Category.Update;
    protected override string DeletePolicyName { get; set; } = ProductManagementPermissions.Category.Delete;

    private readonly ICategoryRepository _repository;

    public CategoryAppService(ICategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Category>> CreateFilteredQueryAsync(CategoryGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            ;
    }
}