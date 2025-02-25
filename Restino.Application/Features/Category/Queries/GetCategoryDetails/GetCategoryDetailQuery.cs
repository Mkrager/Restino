using MediatR;

namespace Restino.Application.Features.Category.Queries.GetCategoryDetails
{
    public class GetCategoryDetailQuery : IRequest<CategoryDetailsVm>
    {
        public Guid CategoriesId { get; set; }
    }
}
