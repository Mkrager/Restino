namespace Restino.Application.Features.Accommodation.Queries.SearchAccommodationList
{
    public class CategoryDtoAccommodationSearch
    {
        public Guid CategoriesId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
