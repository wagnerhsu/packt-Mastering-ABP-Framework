using Volo.Abp.Domain.Entities.Auditing;

namespace ProductManagement.Categories;

public class Category : AuditedAggregateRoot<long>
{
    public Category(long id) : base(id)
    {
    }

    public string Name { get; set; }
}