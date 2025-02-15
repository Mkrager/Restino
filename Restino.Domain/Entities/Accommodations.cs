using System.ComponentModel.DataAnnotations;

namespace Restino.Domain.Entities
{
    public class Accommodations
    {
        [Key]
        public Guid AccommodationsId { get; set; }
        public string UserId {  get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortDescription {  get; set; } = string.Empty;
        public string LongDescription {  get; set; } = string.Empty;
        public int Price { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? ImgUrl { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsHotProposition { get; set; }
        public Guid CategoryId { get; set; }
        public Categories Category { get; set; } = default!;
    }
}
