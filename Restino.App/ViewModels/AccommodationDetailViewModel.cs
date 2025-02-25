using System.ComponentModel.DataAnnotations;

namespace Restino.App.ViewModels
{
    public class AccommodationDetailViewModel
    {
        public Guid AccommodationsId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name of the event should be 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be a positive value")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity should be a positive value")]
        public int Capacity { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name of the event should be 50 characters or less")]
        public string? Address { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "The short description can't be longer than 100 characters and shorter than 10")]
        [Display(Name = "Short Description")]
        public string? ShortDescription { get; set; }
        [Required]
        [StringLength(650, MinimumLength = 10, ErrorMessage = "The long description can't be longer than 650 characters and shorter than 10")]
        [Display(Name = "Long Description")]
        public string? LongDescription { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public string? ImgUrl { get; set; }
        public CategoryViewModel? Category { get; set; } = default!;
    }
}
