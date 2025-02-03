using System;
using System.Threading.Tasks;
using ProductManagement.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Products;

public interface IProductAppService :
    ICrudAppService<
        ProductDto,
        Guid,
        ProductGetListInput,
        CreateUpdateProductDto,
        CreateUpdateProductDto>
{
    Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync();
    Task<PagedResultDto<ProductDto>> GetFilterListAsync(ProductGetListInput input);
}