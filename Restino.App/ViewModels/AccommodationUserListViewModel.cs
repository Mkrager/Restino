namespace Restino.App.ViewModels
{
    public class AccommodationUserListViewModel
    {
        public Guid AccommodationsId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Capacity { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
        public bool IsHotProposition { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; } = default!;

    }
}
