using Moq;
using Restino.Application.Contracts.Identity;
using Restino.Application.Contracts.Persistance;
using Restino.Application.DTOs;
using Restino.Domain.Entities;

namespace Restino.Appilcation.UnitTests.Mock
{
    public class RepositoryMocks
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = MockData.GetCategories();
            var accommodations = MockData.GetAccommodations();

            foreach (var category in categories)
            {
                category.Accommodations = accommodations.Where(a => a.CategoryId == category.CategoriesId).ToList();
            }


            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.GetCategoryWithAccommodation(It.IsAny<bool>(), It.IsAny<Guid>())).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Categories>
                ())).ReturnsAsync(
                (Categories category) =>
                {
                    category.CategoriesId = Guid.NewGuid();
                    categories.Add(category);
                    return category;
                });

            mockCategoryRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>
                ())).ReturnsAsync(
                (Guid id) =>
                {
                    return categories.FirstOrDefault(category => category.CategoriesId == id);
                });

            mockCategoryRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Categories>())).Callback<Categories>(
                (Categories category) =>
                {
                    categories.Remove(category);
                }).Returns(Task.CompletedTask);

            var categoryNames = categories.Select(c => c.CategoryName).ToList();

            mockCategoryRepository.Setup(repo => repo.IsCategoryNameUnique(It.Is<string>(name =>
                categories.Any(c => c.CategoryName == name))))
                .ReturnsAsync(true);

            mockCategoryRepository.Setup(repo => repo.GetCategoryWithAccommodation(It.IsAny<bool>(), It.IsAny<Guid?>()))
               .ReturnsAsync((bool onlyOneCategoryResult, Guid? categoryId) =>
               {
                   var allCategories = categories.AsQueryable();

                   if (onlyOneCategoryResult && categoryId.HasValue)
                   {
                       allCategories = allCategories.Where(x => x.Accommodations.Any(a => a.CategoryId == categoryId.Value));
                   }

                   return allCategories.ToList();
               });


            return mockCategoryRepository;
        }

        public static Mock<IAccommodationRepository> GetAccommodationRepository()
        {
            var accommodations = MockData.GetAccommodations();
            var categories = MockData.GetCategories();
            var mockAccommodationRepository = new Mock<IAccommodationRepository>();

            mockAccommodationRepository.Setup(repo => repo.ListAllAccommodations(It.IsAny<bool>
                ())).ReturnsAsync(
                (bool? isAccommodationHot) =>
                {
                    if (isAccommodationHot == true)
                    {
                        return accommodations.Where(a => a.IsHotProposition == isAccommodationHot.Value).ToList();
                    }
                    return accommodations.ToList();
                });

            mockAccommodationRepository.Setup(repo => repo.AddAsync(It.IsAny<Accommodations>
            ())).ReturnsAsync(
            (Accommodations accommodation) =>
            {
                accommodation.AccommodationsId = Guid.NewGuid();
                accommodations.Add(accommodation);
                return accommodation;
            });

            mockAccommodationRepository.Setup(repo =>
                    repo.IsAccommodationNameAndCategoryUnique(It.IsAny<string>(), It.IsAny<Guid>()))
                .ReturnsAsync((string name, Guid categoryId) =>
                {
                    return accommodations.Any(a => a.Name == name && a.CategoryId == categoryId);
                });

            mockAccommodationRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Accommodations>())).Callback<Accommodations>(
            (Accommodations accommodation) =>
            {
                accommodations.Remove(accommodation);
            }).Returns(Task.CompletedTask);

            mockAccommodationRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>
            ())).ReturnsAsync(
            (Guid id) =>
            {
                return accommodations.FirstOrDefault(accommodation => accommodation.AccommodationsId == id);
            });

            mockAccommodationRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Accommodations>()))
                .Returns((Accommodations accommodation) =>
                {
                    var existingAccommodation = accommodations.FirstOrDefault(a => a.AccommodationsId == accommodation.AccommodationsId);
                    if (existingAccommodation != null)
                    {
                        existingAccommodation.Name = accommodation.Name;
                        existingAccommodation.Address = accommodation.Address;
                        existingAccommodation.Capacity = accommodation.Capacity;
                        existingAccommodation.CategoryId = accommodation.CategoryId;
                        existingAccommodation.ShortDescription = accommodation.ShortDescription;
                        existingAccommodation.ImgUrl = accommodation.ImgUrl;
                        existingAccommodation.Price = accommodation.Price;
                    }

                    return Task.FromResult(existingAccommodation);
                });

            mockAccommodationRepository.Setup(repo => repo.SearchAccommodation(It.IsAny<string>()))
                .ReturnsAsync((string name) =>
                {
                    var accommodations = MockData.GetAccommodations();
                    return accommodations.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                });

            mockAccommodationRepository.Setup(repo => repo.CheckUserPermissionAsync(It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<string>()))
                .ReturnsAsync((string userId, Guid entityId, string userRole) =>
                {
                    var accommodation = accommodations.FirstOrDefault(a => a.AccommodationsId == entityId);

                    if (accommodation == null)
                    {
                        return false;
                    }

                    if (accommodation.UserId == userId || userRole == "Admin")
                    {
                        return true;
                    }

                    return false;
                });
            mockAccommodationRepository.Setup(repo => repo.ListUserAccommodations(It.IsAny<string>()))
                .ReturnsAsync((string userId) =>
                {
                    var userReservations = accommodations.Where(r => r.UserId == userId).ToList();

                    return userReservations;
                });

            return mockAccommodationRepository;
        }

        public static Mock<IReservationRepository> GetReservationRepository()
        {
            var reservations = MockData.GetReservations();
            var accommodations = MockData.GetAccommodations();

            var mockReservationRepository = new Mock<IReservationRepository>();
            mockReservationRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(reservations);

            mockReservationRepository.Setup(repo => repo.AddAsync(It.IsAny<Reservations>
            ())).ReturnsAsync(
            (Reservations reservation) =>
            {
                reservation.ReservationId = Guid.NewGuid();
                reservations.Add(reservation);
                return reservation;
            });

            mockReservationRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Reservations>())).Callback<Reservations>(
                (Reservations reservation) =>
                {
                    reservations.Remove(reservation);
                }).Returns(Task.CompletedTask);

            mockReservationRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>
                ())).ReturnsAsync(
                (Guid id) =>
                {
                    return reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
                });

            mockReservationRepository.Setup(repo => repo.IsDateRangeValid(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<Guid>()))
                .ReturnsAsync((DateTime checkInDate, DateTime checkOutDate, Guid accommodationId) =>
                {
                    return reservations.Any(r =>
                    r.AccommodationsId == accommodationId &&
                    checkInDate < r.CheckOutDate &&
                     checkOutDate > r.CheckInDate);
                });

            mockReservationRepository.Setup(repo => repo.IsGuestsCountWithinCapacity(It.IsAny<int>(), It.IsAny<Guid>()))
                .ReturnsAsync((int guestsCount, Guid accommodationId) =>
                {
                    var accommodation = accommodations.FirstOrDefault(a => a.AccommodationsId == accommodationId);
                    if (accommodation == null)
                    {
                        return false;
                    }

                    return guestsCount > accommodation.Capacity;
                });

            mockReservationRepository.Setup(repo => repo.CheckUserPermissionAsync(It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<string>()))
                .ReturnsAsync((string userId, Guid entityId, string userRole) =>
                {
                    var reservation = reservations.FirstOrDefault(a => a.ReservationId == entityId);

                    if (reservation == null)
                    {
                        return false;
                    }

                    if (reservation.UserId == userId || userRole == "Admin")
                    {
                        return true;
                    }

                    return false;
                });

            mockReservationRepository.Setup(repo => repo.ListUserReservations(It.IsAny<string>()))
                .ReturnsAsync((string userId) =>
                {
                    var userReservations = reservations.Where(r => r.UserId == userId).ToList();

                    return userReservations;
                });

            return mockReservationRepository;
        }

        public static Mock<IAuthenticationService> GetAuthenticationService()
        {
            var mockAuthenticationService = new Mock<IAuthenticationService>();

            return mockAuthenticationService;
        }

        public static Mock<IUserService> GetUserService()
        {
            var users = new List<GetUserDetailsResponse>
    {
        new GetUserDetailsResponse { UserId = "35b820e5-1cea-47c8-a6a0-cedccfbda4e6", UserName = "user1", Email = "user1@example.com", FirstName = "John", LastName = "Doe" },
        new GetUserDetailsResponse { UserId = "35b820e5-1cea-47c8-a6a0-cedccfbda4e1", UserName = "user2", Email = "user2@example.com", FirstName = "John2", LastName = "Doe2" }
    };

            var mockUserService = new Mock<IUserService>();

            mockUserService
                .Setup(service => service.GetUserDetailsAsync(It.IsAny<string>()))
                .ReturnsAsync((string userId) => users.FirstOrDefault(u => u.UserId == userId));

            mockUserService
                .Setup(service => service.GetUserId())
                .ReturnsAsync(users.First().UserId);

            return mockUserService;
        }
    }
}

