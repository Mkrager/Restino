using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Accommodation.Commands.UpdateAccommodation
{
    public class UpdateAccommodationCommandHandler : IRequestHandler<UpdateAccommodationCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAccommodationRepository _accommodationRepository;

        public UpdateAccommodationCommandHandler(IMapper mapper, IAccommodationRepository accommodationRepository)
        {
            _mapper = mapper;
            _accommodationRepository = accommodationRepository;
        }

        public async Task<Unit> Handle(UpdateAccommodationCommand request, CancellationToken cancellationToken)
        {
            var accommodationToUpdate = await _accommodationRepository.GetByIdAsync(request.AccommodationsId);

            if (accommodationToUpdate == null)
            {
                throw new NotFoundException(nameof(Accommodations), request.AccommodationsId);
            }

            var validator = new UpdateAccommodationCommandValidator(_accommodationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var originalUserId = accommodationToUpdate.UserId;

            _mapper.Map(request, accommodationToUpdate, typeof(UpdateAccommodationCommand), typeof(Accommodations));

            if (request.UserRole == "Admin")
            {
                accommodationToUpdate.UserId = originalUserId;
            }

            await _accommodationRepository.UpdateAsync(accommodationToUpdate);

            return Unit.Value;
        }
    }
}
