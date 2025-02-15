using MediatR;
using Restino.Application.DTOs;

namespace Restino.Application.Features.Accounts.Queries.GetById
{
    public class GetUserDetailsQuery : IRequest<GetUserDetailsResponse>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
