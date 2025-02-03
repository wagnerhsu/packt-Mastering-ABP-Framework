using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Products;
using ProductManagement.Products.Dtos;
using ProductManagement.Web.Pages.Products.Product.ViewModels;

namespace ProductManagement.Web.Pages.Products.Product;

public class EditModalModel : ProductManagementPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditProductViewModel ViewModel { get; set; }
    public SelectListItem[] Categories { get; set; }

    private readonly IProductAppService _productAppService;

    public EditModalModel(IProductAppService service)
    {
        _productAppService = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _productAppService.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ProductDto, CreateEditProductViewModel>(dto);
        var categoryLookup = await _productAppService.GetCategoryLookupAsync();
        Categories = categoryLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToArray();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(ViewModel);
        await _productAppService.UpdateAsync(Id, dto);
        return NoContent();
    }
}