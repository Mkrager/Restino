using MediatR;

namespace Restino.Application.Features.Accommodation.Queries.SearchAccommodationList
{
    public class SearchAccommodationListQuery : IRequest<List<SearchAccommodationListVm>>
    {
        public string? Name { get; set; }
    }
}
