using Restino.Domain.Entities;

namespace Restino.Appilcation.UnitTests.Mock
{
    public class MockData
    {
        public static List<Categories> GetCategories()
        {
            var appartamentsGuid = Guid.Parse("c119661c-1d5a-42c1-8819-6b0885af4d4a");
            var villaGuid = Guid.Parse("8f67819c-0d09-43e8-b64f-17c9123b6040");
            var chaletGuid = Guid.Parse("418ade5f-d0b7-4545-b9de-beafbefffa66");
            var cottageGuid = Guid.Parse("cf0976f2-83c1-4708-afea-3e4785db6d66");
            var glampingGuid = Guid.Parse("d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d");
            var hostelGuid = Guid.Parse("9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a");
            var campingGuid = Guid.Parse("6f80d6e0-54b3-495d-847b-16a092c8b626");

            return new List<Categories>
            {
                new Categories
                {
                    CategoriesId = appartamentsGuid,
                    CategoryName = "Appartaments",
                    Description = "Apartments are a modern type of accommodation...",
                    ImgUrl = "https://cdn.pixabay.com/photo/2016/11/30/08/48/bedroom-1872196_1280.jpg"
                },
                new Categories
                {
                    CategoriesId = villaGuid,
                    CategoryName = "Villa",
                    Description = "A villa is a luxurious house typically situated...",
                    ImgUrl = "https://cdn.pixabay.com/photo/2013/10/12/18/05/villa-194671_1280.jpg"
                },
                new Categories
                {
                    CategoriesId = chaletGuid,
                    CategoryName = "Chalet",
                    Description = "A chalet is a traditional mountain house...",
                    ImgUrl = "https://cdn.pixabay.com/photo/2019/12/11/12/00/mountain-4688203_1280.jpg"
                },
                new Categories
                {
                    CategoriesId = cottageGuid,
                    CategoryName = "Cottage",
                    Description = "A cottage is a small country house offering...",
                    ImgUrl = "https://cdn.pixabay.com/photo/2015/08/25/14/16/small-wooden-house-906912_1280.jpg"
                },
                new Categories
                {
                    CategoriesId = glampingGuid,
                    CategoryName = "Glamping",
                    Description = "Glamping is a combination of luxury and closeness to nature...",
                    ImgUrl = "https://cdn.pixabay.com/photo/2021/07/25/06/26/glamping-6490987_1280.jpg"
                },
                new Categories
                {
                    CategoriesId = hostelGuid,
                    CategoryName = "Hostel",
                    Description = "A hostel is a budget-friendly accommodation option...",
                    ImgUrl = "https://cdn.pixabay.com/photo/2013/06/30/19/07/bed-142516_1280.jpg"
                },
                new Categories
                {
                    CategoriesId = campingGuid,
                    CategoryName = "Camping",
                    Description = "Camping is a way to spend time in nature...",
                    ImgUrl = "https://cdn.pixabay.com/photo/2017/08/17/08/08/camp-2650359_1280.jpg"
                }
            };
        }

        public static List<Accommodations> GetAccommodations()
        {
            var appartamentsGuid = Guid.Parse("c119661c-1d5a-42c1-8819-6b0885af4d4a");
            var villaGuid = Guid.Parse("8f67819c-0d09-43e8-b64f-17c9123b6040");
            var chaletGuid = Guid.Parse("418ade5f-d0b7-4545-b9de-beafbefffa66");
            var cottageGuid = Guid.Parse("cf0976f2-83c1-4708-afea-3e4785db6d66");
            var glampingGuid = Guid.Parse("d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d");
            var hostelGuid = Guid.Parse("9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a");
            var campingGuid = Guid.Parse("6f80d6e0-54b3-495d-847b-16a092c8b626");

            return new List<Accommodations>
            {
                new Accommodations
                {
                    AccommodationsId = Guid.Parse("1a4ab6df-66b8-46f7-8198-c94332964001"),
                    Name = "City View Apartment",
                    Address = "101 Central St, Cityville",
                    Capacity = 4,
                    CreatedDate = DateTime.Today.AddDays(20),
                    CategoryId = appartamentsGuid,
                    IsHotProposition = true,
                    ShortDescription = "A modern apartment with a city view.",
                    ImgUrl = "https://cdn.pixabay.com/photo/2015/09/05/21/51/room-924058_1280.jpg",
                    Price = 7000
                },
                new Accommodations
                {
                    AccommodationsId = Guid.Parse("2a4ab6df-66b8-46f7-8198-c94332964002"),
                    Name = "Oceanfront Villa",
                    Address = "202 Ocean Dr, Beachside",
                    Capacity = 8,
                    CreatedDate = DateTime.Today.AddDays(15),
                    CategoryId = villaGuid,
                    IsHotProposition = true,
                    ShortDescription = "A luxury villa with oceanfront views.",
                    ImgUrl = "https://cdn.pixabay.com/photo/2015/03/12/12/05/sunset-670032_1280.jpg",
                    Price = 12000,
                    UserId = "12334556456745"
                },
                new Accommodations
                {
                    AccommodationsId = Guid.Parse("3a4ab6df-66b8-46f7-8198-c94332964003"),
                    Name = "Mountain Retreat Chalet",
                    Address = "303 Alpine Rd, Mount Valley",
                    Capacity = 6,
                    CreatedDate = DateTime.Today.AddDays(18),
                    CategoryId = chaletGuid,
                    IsHotProposition = false,
                    ShortDescription = "A cozy retreat in the mountains.",
                    ImgUrl = "https://cdn.pixabay.com/photo/2015/09/05/20/02/mountain-hut-924050_1280.jpg",
                    Price = 8500
                },
                new Accommodations
                {
                    AccommodationsId = Guid.Parse("4a4ab6df-66b8-46f7-8198-c94332964004"),
                    Name = "Forest Hideaway Cottage",
                    Address = "404 Green Ln, Woodland",
                    Capacity = 5,
                    CreatedDate = DateTime.Today.AddDays(12),
                    CategoryId = cottageGuid,
                    IsHotProposition = false,
                    ShortDescription = "A peaceful cottage in the forest.",
                    ImgUrl = "https://cdn.pixabay.com/photo/2015/09/01/09/14/cabin-914092_1280.jpg",
                    Price = 6000
                },
                new Accommodations
                {
                    AccommodationsId = Guid.Parse("5a4ab6df-66b8-46f7-8198-c94332964005"),
                    Name = "Luxury Glamping Tent",
                    Address = "505 Camp Rd, Nature Reserve",
                    Capacity = 2,
                    CreatedDate = DateTime.Today.AddDays(10),
                    CategoryId = glampingGuid,
                    IsHotProposition = true,
                    ShortDescription = "A luxurious glamping experience.",
                    ImgUrl = "https://cdn.pixabay.com/photo/2016/11/21/15/53/camping-1840052_1280.jpg",
                    Price = 5000
                },
                new Accommodations
                {
                    AccommodationsId = Guid.Parse("6a4ab6df-66b8-46f7-8198-c94332964006"),
                    Name = "Downtown Hostel",
                    Address = "606 Urban St, Metro City",
                    Capacity = 10,
                    CreatedDate = DateTime.Today.AddDays(8),
                    CategoryId = hostelGuid,
                    IsHotProposition = false,
                    ShortDescription = "A friendly hostel in the city center.",
                    ImgUrl = "https://cdn.pixabay.com/photo/2017/01/22/14/14/hostel-1990300_1280.jpg",
                    Price = 1500
                },
                new Accommodations
                {
                    AccommodationsId = Guid.Parse("7a4ab6df-66b8-46f7-8198-c94332964007"),
                    Name = "Desert Camping",
                    Address = "15 Sand Dune Rd, Nevada, NV",
                    Capacity = 5,
                    CreatedDate = DateTime.Today.AddDays(24),
                    CategoryId = campingGuid,
                    IsHotProposition = true,
                    ShortDescription = "An adventurous camping experience in the desert.",
                    ImgUrl = "https://www.hostelworld.com/blog/wp-content/uploads/2023/04/parker-hilton-VtGLcivTXtk-unsplash.jpg",
                    Price = 4500
                }
            };
        }

        public static List<Reservations> GetReservations()
        {
            return new List<Reservations>
            {
                new Reservations
                {
                    ReservationId = Guid.Parse("7a4ab6df-66b8-55f7-6698-c94332964007"),
                    AccommodationsId = Guid.Parse("1a4ab6df-66b8-46f7-8198-c94332964001"),
                    AdditionalServices = "test",
                    CustomerNote = "test",
                    GuestsCount = 1,
                    CheckInDate = DateTime.Today,
                    CheckOutDate = DateTime.Today.AddDays(42),
                    UserId = "534ab6df-66b8-46f7-8198-c94332964001"
                }
            };
        }
    }
}
