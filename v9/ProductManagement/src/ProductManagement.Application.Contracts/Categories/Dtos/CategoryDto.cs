using System;
using Volo.Abp.Application.Dtos;

namespace ProductManagement.Categories.Dtos;

[Serializable]
public class CategoryDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
}