using System.ComponentModel.DataAnnotations;

namespace Restino.App.ViewModels
{
    public class CategoryViewModel
    {
        public Guid CategoriesId { get; set; }

        [Display(Name = "Name")]
        public string CategoryName { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
