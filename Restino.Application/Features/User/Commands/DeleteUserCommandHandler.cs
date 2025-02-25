using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Identity;

namespace Restino.Application.Features.User.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public DeleteUserCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeleteUser(request.UserId);
            return Unit.Value;
        }
    }
}
