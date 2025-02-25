using AutoMapper;
using Restino.Application.Features.Accommodation.Commands.CreateAccommodation;
using Restino.Application.Features.Accommodation.Commands.DeleteAccommodation;
using Restino.Application.Features.Accommodation.Commands.UpdateAccommodation;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationDetails;
using Restino.Application.Features.Accommodation.Queries.GetAccommodationList;
using Restino.Application.Features.Accommodation.Queries.GetUserAccommodationList;
using Restino.Application.Features.Accommodation.Queries.SearchAccommodationList;
using Restino.Application.Features.Category.Commands.CreateCategoryCommand;
using Restino.Application.Features.Category.Queries.GetCategoriesList;
using Restino.Application.Features.Category.Queries.GetCategoriesListWithAccommodation;
using Restino.Application.Features.Category.Queries.GetCategoryDetails;
using Restino.Application.Features.Reservation.Commands.CreateReservation;
using Restino.Application.Features.Reservation.Commands.DeleteReservation;
using Restino.Application.Features.Reservation.Queries.GetReservatioDetails;
using Restino.Application.Features.Reservation.Queries.GetReservationList;
using Restino.Application.Features.Reservation.Queries.GetUserReservations;
using Restino.Domain.Entities;

namespace Restino.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Accommodations, AccommodationListVm>().ReverseMap();
            CreateMap<Accommodations, AccommodationDetailsVm>().ReverseMap();
            CreateMap<Accommodations, CreateAccommodationCommand>().ReverseMap();
            CreateMap<Accommodations, UpdateAccommodationCommand>().ReverseMap();
            CreateMap<Accommodations, DeleteAccommodationCommand>().ReverseMap();
            CreateMap<Accommodations, CategoryAccommodationDto>().ReverseMap();
            CreateMap<Accommodations, SearchAccommodationListVm>().ReverseMap();
            CreateMap<Accommodations, UserAccommodationListVm>().ReverseMap();


            CreateMap<Categories, CategoryDetailsVm>().ReverseMap();
            CreateMap<Categories, CategoryDto>();
            CreateMap<Categories, CategoryDtoAccommodationSearch>();
            CreateMap<Categories, CategoryUserDtoAccommodation>();
            CreateMap<Categories, CategoryDtoAccommodation>();
            CreateMap<Categories, CategoryListVm>();
            CreateMap<Categories, CategoryAccommodationListVm>();
            CreateMap<Categories, CreateCategoryCommand>();

            CreateMap<Reservations, CreateReservationCommand>().ReverseMap();
            CreateMap<Reservations, ReservationListVm>().ReverseMap();
            CreateMap<Reservations, ReservationDetailsVm>().ReverseMap();
            CreateMap<Reservations, DeleteReservationCommand>().ReverseMap();
            CreateMap<Reservations, GetUserReservationListVm>().ReverseMap();
        }
    }
}
