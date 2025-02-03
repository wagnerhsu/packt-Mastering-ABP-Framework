using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Categories.Dtos;

[Serializable]
public class CategoryGetListInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }
}