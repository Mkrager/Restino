using MediatR;
using Restino.Application.DTOs;

namespace Restino.Application.Features.User.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<GetUserDetailsResponse>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
