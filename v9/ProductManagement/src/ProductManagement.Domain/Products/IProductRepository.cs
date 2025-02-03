using System;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Products;

public interface IProductRepository : IRepository<Product, Guid>
{
}
