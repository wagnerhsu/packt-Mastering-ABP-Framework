using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace ProductManagement.Web.Pages.Categories.Category;

public class IndexModel : ProductManagementPageModel
{
    public CategoryFilterInput CategoryFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class CategoryFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "CategoryName")]
    public string? Name { get; set; }
}
