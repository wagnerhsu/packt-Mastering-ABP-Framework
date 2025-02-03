using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Logging;
using ProductManagement.Categories;
using ProductManagement.Permissions;
using ProductManagement.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace ProductManagement.Products;

public class ProductAppService :
    CrudAppService<Product, // The Product entity
        ProductDto,
        Guid, // Primary key of the product entity
        ProductGetListInput, // Used for paging/sorting
        CreateUpdateProductDto, // Used to create a product
        CreateUpdateProductDto>, // Used to update a product
    IProductAppService
{
    protected override string GetPolicyName { get; set; } = ProductManagementPermissions.Product.Default;
    protected override string GetListPolicyName { get; set; } = ProductManagementPermissions.Product.Default;
    protected override string CreatePolicyName { get; set; } = ProductManagementPermissions.Product.Create;
    protected override string UpdatePolicyName { get; set; } = ProductManagementPermissions.Product.Update;
    protected override string DeletePolicyName { get; set; } = ProductManagementPermissions.Product.Delete;

    private readonly IProductRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<ProductAppService> _logger;

    public ProductAppService(IProductRepository repository,
        ICategoryRepository categoryRepository,
        ILogger<ProductAppService> logger) : base(repository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public override async Task<ProductDto> GetAsync(Guid id)
    {
        _logger.LogDebug("Getting product with id: {id}", id);
        var queryable = await Repository.GetQueryableAsync();

        var query = from product in queryable
            join category in await _categoryRepository.GetQueryableAsync() on product.CategoryId equals category.Id
            where product.Id == id
            select new { product, category };

        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Product), id);
        }

        var productDto = ObjectMapper.Map<Product, ProductDto>(queryResult.product);
        productDto.CategoryName = queryResult.category.Name;
        return productDto;
    }


    public override async Task<PagedResultDto<ProductDto>> GetListAsync(ProductGetListInput input)
    {
        var queryable = await Repository.GetQueryableAsync();

        var query = from product in queryable
            join category in await _categoryRepository.GetQueryableAsync() on product.CategoryId equals category.Id
            select new { product, category };

        //Paging
        query = query
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of productDto objects
        var productDtos = queryResult.Select(x =>
        {
            var productDto = ObjectMapper.Map<Product, ProductDto>(x.product);
            productDto.CategoryName = x.category.Name;
            return productDto;
        }).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<ProductDto>(
            totalCount,
            productDtos
        );
    }

    protected override async Task<IQueryable<Product>> CreateFilteredQueryAsync(ProductGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input));
    }

    public async Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync()
    {
        var categories = await _categoryRepository.GetListAsync();
        return new ListResultDto<CategoryLookupDto>(
            ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories));
    }

    public async Task<PagedResultDto<ProductDto>> GetFilterListAsync(ProductGetListInput input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Product.Name);
        }

        var products = await Repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
        var filteredList = products.WhereIf(!input.Filter.IsNullOrWhiteSpace(),
            x => x.Name.Contains(input.Filter));

        var list = filteredList.ToList();

        return new PagedResultDto<ProductDto>(list.Count(), ObjectMapper.Map<List<Product>, List<ProductDto>>(list));
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"product.{nameof(Product.Name)}";
        }

        if (sorting.Contains("categoryName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "categoryName",
                "category.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"product.{sorting}";
    }
}