namespace Restino.App.ViewModels
{
    public class CategoryAccommodationViewModel
    {
        public Guid CategoriesId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<AccommodationNestedViewModel>? Accommodations { get; set; }
    }
}
