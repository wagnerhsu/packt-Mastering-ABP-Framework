using AutoMapper;
using ProductManagement.Categories;
using ProductManagement.Products;
using ProductManagement.Web.Pages.Products;

namespace ProductManagement.Web;

public class ProductManagementWebAutoMapperProfile : Profile
{
    public ProductManagementWebAutoMapperProfile()
    {
        CreateMap<Category, CategoryLookupDto>();
        CreateMap<ProductDto, CreateEditProductViewModel>();
        CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
    }
}
