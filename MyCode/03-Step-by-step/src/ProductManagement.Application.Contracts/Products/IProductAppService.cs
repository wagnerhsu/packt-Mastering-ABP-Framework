﻿using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Products;

public interface IProductAppService : IApplicationService
{
    Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    Task CreateAsync(CreateUpdateProductDto input);
    Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync();
    Task<ProductDto> GetAsync(long id);
    Task UpdateAsync(long id, CreateUpdateProductDto input);
    Task DeleteAsync(long id);
}