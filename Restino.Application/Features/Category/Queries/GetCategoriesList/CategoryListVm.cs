namespace Restino.Application.Features.Category.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public Guid CategoriesId { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
