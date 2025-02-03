using System;

namespace ProductManagement.Categories.Dtos;

[Serializable]
public class CreateUpdateCategoryDto
{
    public string Name { get; set; }
}