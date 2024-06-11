﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using ProductManagement.Categories;
using SunHealth.Services.UniqueId;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Products;

public class ProductAppService : ProductManagementAppService, IProductAppService
{
    private readonly IRepository<Product, long> _productRepository;
    private readonly IRepository<Category, long> _categoryRepository;
    UniqueIdService _uniqueIdService = new();


    public ProductAppService(IRepository<Product, long> productRepository,
        IRepository<Category, long> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _productRepository.WithDetailsAsync(x => x.Category);
        queryable = queryable.Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .OrderBy(input.Sorting ?? nameof(Product.Name));


        var products = await AsyncExecuter.ToListAsync<Product>(queryable);
        var count = await _productRepository.GetCountAsync();

        var dtos = new PagedResultDto<ProductDto>(
            count,
            ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
        );
        return dtos;
    }

    public async Task CreateAsync(CreateUpdateProductDto input)
    {
        var product = new Product(_uniqueIdService.GenerateInt64());
        ObjectMapper.Map(input, product);

        await _productRepository.InsertAsync(product);
    }

    public async Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetListAsync();
        return new ListResultDto<CategoryLookupDto>(
            ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories));
    }

    public async Task<ProductDto> GetAsync(long id)
    {
        var product = await _productRepository.GetAsync(id);
        return ObjectMapper.Map<Product, ProductDto>(product);
    }

    public async Task UpdateAsync(long id, CreateUpdateProductDto input)
    {
        var product = await _productRepository.GetAsync(id);
        ObjectMapper.Map(input, product);
    }

    public async Task DeleteAsync(long id)
    {
        await _productRepository.DeleteAsync(id);
    }
}