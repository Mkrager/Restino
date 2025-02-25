using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Identity;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Accommodation.Commands.CreateAccommodation
{
    public class CreateAccommodationCommandHandler : IRequestHandler<CreateAccommodationCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly IUserService _userService;

        public CreateAccommodationCommandHandler(IMapper mapper, IAccommodationRepository accommodationRepository, IUserService userService)
        {
            _accommodationRepository = accommodationRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<Guid> Handle(CreateAccommodationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccommodationCommandValidator(_accommodationRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            var accommodation = new Accommodations()
            {
                Name = request.Name,
                Address = request.Address,
                Capacity = request.Capacity,
                CategoryId = request.CategoryId,
                ShortDescription = request.ShortDescription,
                LongDescription = request.LongDescription,
                ImgUrl = request.ImgUrl,
                Price = request.Price,
                UserId = await _userService.GetUserId()
            };

            accommodation = await _accommodationRepository.AddAsync(accommodation);

            accommodation = _mapper.Map<Accommodations>(accommodation);

            return accommodation.AccommodationsId;
        }
    }
}

