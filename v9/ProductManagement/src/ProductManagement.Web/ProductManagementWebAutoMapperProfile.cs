using ProductManagement.Categories.Dtos;
using ProductManagement.Web.Pages.Categories.Category.ViewModels;
using ProductManagement.Products.Dtos;
using ProductManagement.Web.Pages.Products.Product.ViewModels;
using AutoMapper;

namespace ProductManagement.Web;

public class ProductManagementWebAutoMapperProfile : Profile
{
    public ProductManagementWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        CreateMap<CategoryDto, CreateEditCategoryViewModel>();
        CreateMap<CreateEditCategoryViewModel, CreateUpdateCategoryDto>();
        CreateMap<ProductDto, CreateEditProductViewModel>();
        CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
    }
}
