using AutoMapper;
using MediatR;
using Restino.Application.Contracts.Persistance;
using Restino.Application.Exceptions;
using Restino.Domain.Entities;

namespace Restino.Application.Features.Accommodation.Commands.DeleteAccommodation
{
    public class DeleteAccommodationCommandHandler : IRequestHandler<DeleteAccommodationCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Accommodations> _accommodationRepository;

        public DeleteAccommodationCommandHandler(IMapper mapper, IAsyncRepository<Accommodations> accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAccommodationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteAccommodationCommandValidator(_accommodationRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            var accommodationToDelete = await _accommodationRepository.GetByIdAsync(request.AccommodationsId);
            await _accommodationRepository.DeleteAsync(accommodationToDelete);

            return Unit.Value;
        }
    }
}
