using Volo.Abp.Domain.Entities.Auditing;

namespace ProductManagement.Categories;

public class Category : AuditedAggregateRoot<string>
{
    public Category(string id) : base(id)
    {
    }

    public string Name { get; set; }
}