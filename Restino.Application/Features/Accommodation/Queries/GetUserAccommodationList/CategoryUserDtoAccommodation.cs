namespace Restino.Application.Features.Accommodation.Queries.GetUserAccommodationList
{
    public class CategoryUserDtoAccommodation
    {
        public Guid CategoriesId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
