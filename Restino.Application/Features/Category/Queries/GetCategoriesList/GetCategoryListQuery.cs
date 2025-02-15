using MediatR;

namespace Restino.Application.Features.Category.Queries.GetCategoriesList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
