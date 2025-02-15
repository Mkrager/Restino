namespace Restino.App.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public Guid CategoriesId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
    }
}
