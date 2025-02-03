using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProductManagement.Categories;
using ProductManagement.Products;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace ProductManagement.Web.Pages.Products.Product;

public class IndexModel : ProductManagementPageModel
{
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}