namespace Restino.Application.Features.Category.Queries.GetCategoriesListWithAccommodation
{
    public class CategoryAccommodationListVm
    {
        public Guid CategoriesId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public ICollection<CategoryAccommodationDto>? Accommodations { get; set; }
    }
}
