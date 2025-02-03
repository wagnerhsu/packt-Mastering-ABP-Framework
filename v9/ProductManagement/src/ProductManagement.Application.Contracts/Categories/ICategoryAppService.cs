using System;
using ProductManagement.Categories.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Categories;


public interface ICategoryAppService :
    ICrudAppService< 
        CategoryDto, 
        Guid, 
        CategoryGetListInput,
        CreateUpdateCategoryDto,
        CreateUpdateCategoryDto>
{

}