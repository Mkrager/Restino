using System.Text.Json.Serialization;

namespace Restino.Application.Features.Accommodation.Queries.GetAccommodationDetails
{
    public class AccommodationDetailsVm : CategoryDto
    {
        //[JsonPropertyName("CategoriesId")]
        public Guid AccommodationsId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Guid CategoryId { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public CategoryDto Category { get; set; } = default!;
    }
}
