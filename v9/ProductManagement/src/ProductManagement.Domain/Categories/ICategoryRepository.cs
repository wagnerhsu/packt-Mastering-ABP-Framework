using System;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Categories;

public interface ICategoryRepository : IRepository<Category, Guid>
{
}
