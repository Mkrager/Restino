using System.Text.Json.Serialization;

namespace Restino.Application.Features.Category.Queries.GetCategoryDetails
{
    public class CategoryDetailsVm
    {
        [JsonPropertyName("CategoriesId")]
        public Guid CategoriesId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
    }
}
