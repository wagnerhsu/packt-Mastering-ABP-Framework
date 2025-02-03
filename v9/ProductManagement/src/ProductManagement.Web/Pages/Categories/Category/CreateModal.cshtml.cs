using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Categories;
using ProductManagement.Categories.Dtos;
using ProductManagement.Web.Pages.Categories.Category.ViewModels;

namespace ProductManagement.Web.Pages.Categories.Category;

public class CreateModalModel : ProductManagementPageModel
{
    [BindProperty]
    public CreateEditCategoryViewModel ViewModel { get; set; }

    private readonly ICategoryAppService _service;

    public CreateModalModel(ICategoryAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}