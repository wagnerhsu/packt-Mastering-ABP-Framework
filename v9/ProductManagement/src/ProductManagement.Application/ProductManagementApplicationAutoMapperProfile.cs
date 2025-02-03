using ProductManagement.Categories;
using ProductManagement.Categories.Dtos;
using ProductManagement.Products;
using ProductManagement.Products.Dtos;
using AutoMapper;

namespace ProductManagement;

public class ProductManagementApplicationAutoMapperProfile : Profile
{
    public ProductManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>(MemberList.Source);
        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>(MemberList.Source);
        
        CreateMap<Category,CategoryLookupDto>();
    }
}
