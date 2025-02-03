using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductManagement.Products;
using ProductManagement.Products.Dtos;
using ProductManagement.Web.Pages.Products.Product.ViewModels;

namespace ProductManagement.Web.Pages.Products.Product;

public class CreateModalModel : ProductManagementPageModel
{
    [BindProperty]
    public CreateEditProductViewModel ViewModel { get; set; }
    public SelectListItem[] Categories { get; set; }
    private readonly IProductAppService _productAppService;

    public CreateModalModel(IProductAppService service)
    {
        _productAppService = service;
    }

    public async Task OnGetAsync()
    {
        ViewModel = new CreateEditProductViewModel
        {
            ReleaseDate = Clock.Now,
            StockState = ProductStockState.PreOrder
        };

        var categoryLookup =
            await _productAppService.GetCategoryLookupAsync();
        Categories = categoryLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToArray();
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(ViewModel);
        await _productAppService.CreateAsync(dto);
        return NoContent();
    }
}