//using AutoMapper;
//using Restino.App.ViewModels;
//namespace Restino.App.Profiles
//{
//    public class Mappings : Profile
//    {
//        public Mappings()
//        {
//            CreateMap<AccommodationListVm, AccommodationListViewModel>().ReverseMap();
//            CreateMap<AccommodationDetailsVm, AccommodationDetailViewModel>().ReverseMap();
//            CreateMap<AccommodationSearchListViewModel, SearchAccommodationListQueryResponse>().ReverseMap();
//            CreateMap<SearchAccommodationListVm, AccommodationSearchListViewModel>().ReverseMap();
//            CreateMap<AccommodationDetailViewModel, CreateAccommodationCommand>().ReverseMap();
//            CreateMap<AccommodationDetailViewModel, CreateAccommodationDto>().ReverseMap();
//            CreateMap<AccommodationDetailViewModel, UpdateAccommodationCommand>().ReverseMap();
//            CreateMap<AccommodationDetailViewModel, UpdateAccommodationDto>().ReverseMap();
//            CreateMap<AccommodationUserListViewModel, AccommodationListVm>().ReverseMap();

//            CreateMap<CategoryAccommodationDto, AccommodationNestedViewModel>().ReverseMap();

//            CreateMap<CategoryDetailsVm, CategoryDetailsViewModel>().ReverseMap();
//            CreateMap<CategoryListVm, CategoryAccommodationViewModel>().ReverseMap();
//            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
//            CreateMap<CategoryDtoAccommodationSearch, CategoryDtoAccommodationSearchViewModel>().ReverseMap();
//            CreateMap<CategoryDtoAccommodation, CategoryViewModel>().ReverseMap();
//            CreateMap<CategoryListVm, CategoryViewModel>().ReverseMap();
//            CreateMap<CategoryAccommodationListVm, CategoryAccommodationViewModel>().ReverseMap();
//            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();
//            CreateMap<CreateCategoryDto, CategoryDto>().ReverseMap();

//            CreateMap<CreateReservationCommand, ReservationDetailViewModel>().ReverseMap();
//            CreateMap<ReservationListViewModel, ReservationDto>().ReverseMap();
//            CreateMap<ReservationDetailsVm, ReservationDetailViewModel>().ReverseMap();
//            CreateMap<ReservationListVm, ReservationListViewModel>().ReverseMap();

//            CreateMap<GetByIdResponse, AccountViewModel>().ReverseMap();
//        }
//    }
//}
