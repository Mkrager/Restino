using MediatR;

namespace Restino.Application.Features.Accommodation.Commands.CreateAccommodation
{
    public class CreateAccommodationCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
        public string Address { get; set; } = string.Empty;
        public int Capacity {  get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }

        public override string ToString()
        {
            return $"Accommodation name: {Name}; Price: {Price}; ShortDescription: {ShortDescription}; LongDescription: {LongDescription}; Address: {Address}; Capacity: {Capacity}";
        }
    }
}
