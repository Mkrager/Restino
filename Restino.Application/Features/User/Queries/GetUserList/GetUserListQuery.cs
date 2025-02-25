using MediatR;
using Restino.Application.DTOs;

namespace Restino.Application.Features.User.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<List<GetUserDetailsResponse>>
    {
    }
}
