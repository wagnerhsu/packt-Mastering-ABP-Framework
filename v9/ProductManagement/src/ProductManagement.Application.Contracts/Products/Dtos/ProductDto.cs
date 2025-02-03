using System;
using ProductManagement.Categories;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Products.Dtos;

[Serializable]
public class ProductDto : FullAuditedEntityDto<Guid>
{
    public string CategoryName { get; set; }

    public Guid CategoryId { get; set; }

    public string Name { get; set; }

    public float Price { get; set; }

    public bool IsFreeCargo { get; set; }

    public DateTime ReleaseDate { get; set; }

    public ProductStockState StockState { get; set; }
}