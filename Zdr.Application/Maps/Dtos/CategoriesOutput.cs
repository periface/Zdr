using Abp.Application.Services.Dto;

namespace Zdr.Maps.Dtos
{
    public class CategoriesOutput
    {

    }

    public class CategoryDto : EntityDto
    {
        public string CategoryDisplayName { get; set; }
        public string CategoryName { get; set; }
    }
}
