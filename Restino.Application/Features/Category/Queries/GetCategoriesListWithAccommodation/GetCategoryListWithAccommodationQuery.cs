using MediatR;

namespace Restino.Application.Features.Category.Queries.GetCategoriesListWithAccommodation
{
    public class GetCategoryListWithAccommodationQuery : IRequest<List<CategoryAccommodationListVm>>
    {
        public bool onlyOneCategoryResult;
        public Guid? categoryId;
    }
}
