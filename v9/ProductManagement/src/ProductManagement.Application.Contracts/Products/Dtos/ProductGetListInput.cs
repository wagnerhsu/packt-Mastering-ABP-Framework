using System;
using System.ComponentModel;
using ProductManagement.Categories;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products.Dtos;

[Serializable]
public class ProductGetListInput : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}