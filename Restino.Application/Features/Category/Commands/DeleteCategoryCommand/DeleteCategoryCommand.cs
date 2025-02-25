using MediatR;

namespace Restino.Application.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid CategoriesId { get; set; }
    }
}
