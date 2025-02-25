using Microsoft.EntityFrameworkCore;
using Restino.Domain.Entities;

namespace Restino.Persistence
{
    public class RestinoDbContext : DbContext
    {
        public RestinoDbContext(DbContextOptions<RestinoDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Accommodations> Accommodations { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Reservations> Reservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestinoDbContext).Assembly);

            var appartamentsGuid = Guid.Parse("{c119661c-1d5a-42c1-8819-6b0885af4d4a}");
            var villaGuid = Guid.Parse("{8f67819c-0d09-43e8-b64f-17c9123b6040}");
            var chaletGuid = Guid.Parse("{418ade5f-d0b7-4545-b9de-beafbefffa66}");
            var cottageGuid = Guid.Parse("{cf0976f2-83c1-4708-afea-3e4785db6d66}");
            var glampingGuid = Guid.Parse("{d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d}");
            var hostelGuid = Guid.Parse("{9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a}");
            var campingGuid = Guid.Parse("{6f80d6e0-54b3-495d-847b-16a092c8b626}");

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                CategoriesId = appartamentsGuid,
                CategoryName = "Appartaments",
                Description = "Apartments are a modern type of accommodation that combines the comfort of a home with high-quality service. They are ideal for short-term or long-term stays, offering a fully equipped kitchen, spacious interiors, and modern amenities. Apartments are often located in city centers, providing easy access to popular locations. Choosing apartments ensures independence and comfort for travelers who value coziness and the convenience of a private space.",
                ImgUrl = "https://cdn.pixabay.com/photo/2016/11/30/08/48/bedroom-1872196_1280.jpg"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                CategoriesId = villaGuid,
                CategoryName = "Villa",
                Description = "A villa is a luxurious house typically situated in a picturesque area. It is perfect for large groups or families. Villas come equipped with spacious rooms, terraces, swimming pools, and sometimes even gardens. This type of accommodation is designed for those seeking privacy, comfort, and natural beauty. It’s an excellent choice for hosting parties or enjoying a peaceful retreat away from the hustle and bustle of the city.",
                ImgUrl = "https://cdn.pixabay.com/photo/2013/10/12/18/05/villa-194671_1280.jpg"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                CategoriesId = chaletGuid,
                CategoryName = "Chalet",
                Description = "A chalet is a traditional mountain house made of wood with a warm and cozy interior. They are most commonly found in mountainous regions and are popular among winter sports enthusiasts. Chalets are ideal for family vacations or romantic getaways. The ambiance of these homes promotes complete relaxation, while fireplaces add a touch of coziness on cold winter evenings.",
                ImgUrl = "https://cdn.pixabay.com/photo/2019/12/11/12/00/mountain-4688203_1280.jpg"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                CategoriesId = cottageGuid,
                CategoryName = "Cottage",
                Description = "A cottage is a small country house offering peace and coziness away from the city noise. It usually features a traditional design with modern amenities. Cottages are perfect for family vacations or short getaways into nature. They are often located near forests or lakes, creating ideal conditions for outdoor activities.",
                ImgUrl = "https://cdn.pixabay.com/photo/2015/08/25/14/16/small-wooden-house-906912_1280.jpg"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                CategoriesId = glampingGuid,
                CategoryName = "Glamping",
                Description = "Glamping is a combination of luxury and closeness to nature. This type of accommodation offers tents or wooden cabins with all modern conveniences. Glamping provides an authentic outdoor experience without sacrificing comfort. It is perfect for those who love nature but prefer a more luxurious stay.",
                ImgUrl = "https://cdn.pixabay.com/photo/2021/07/25/06/26/glamping-6490987_1280.jpg"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                CategoriesId = hostelGuid,
                CategoryName = "Hostel",
                Description = "A hostel is a budget-friendly accommodation option for travelers. Typically, it features shared rooms with individual beds, although private rooms are also available. Hostels are ideal for young people and those looking to meet fellow travelers. They often include shared kitchens, common areas, and are usually located in city centers.", 
                ImgUrl = "https://cdn.pixabay.com/photo/2013/06/30/19/07/bed-142516_1280.jpg"
            });

            modelBuilder.Entity<Categories>().HasData(new Categories
            {
                CategoriesId = campingGuid,
                CategoryName = "Camping",
                Description = "Camping is a way to spend time in nature by staying in tents or trailers. It’s a great opportunity to escape civilization, enjoying quiet mornings and starry nights. Campsites are often located near forests, rivers, or mountains, providing opportunities for active leisure such as fishing, hiking, or cycling.", 
                ImgUrl = "https://cdn.pixabay.com/photo/2017/08/17/08/08/camp-2650359_1280.jpg"
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{47fc830b-751c-4b54-88e3-3281d746f3fd}"),
                Name = "Sunrise Apartments",
                Address = "123 Beachside Ave, Miami, FL",
                Capacity = 4,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = appartamentsGuid,
                IsHotProposition = false,
                ShortDescription = "Cozy apartments with a sea view and modern amenities.",
                LongDescription = "Sunrise Apartments offer the perfect seaside getaway with spacious, modern apartments and stunning ocean views. Each apartment features a cozy living room, fully equipped kitchen, comfortable bedrooms, and a stylish bathroom. Ideal for families or groups looking to enjoy the beach and relaxation.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/397741258.jpg?k=225b07468ede098c5df3b7037eaa6b681dd01f94d392a0bb96827f4467515fdd&o=&hp=1",
                Price = 12000,
                UserId = "7678105a-3d95-4c43-a3ac-a717d241a8f1"
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{9db960f8-38e7-4fb4-8db5-6c82f65a654c}"),
                Name = "City View Apartment",
                Address = "98 Main Blvd, Chicago, IL",
                Capacity = 3,
                CreatedDate = DateTime.Today.AddDays(10),
                CategoryId = appartamentsGuid,
                IsHotProposition = false,
                ShortDescription = "Stylish apartment with a stunning view of the city skyline.",
                LongDescription = "This stylish apartment offers large windows with breathtaking views of Chicago's skyline. The modern interior includes a spacious living room, kitchen, and cozy bedrooms, making it perfect for small families or couples who want to experience the vibrant city life.",
                ImgUrl = "https://images.stockcake.com/public/8/8/1/8814dc5c-08e3-48f6-be0a-287e67513bf8_large/city-view-apartment-stockcake.jpg",
                Price = 22000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{6b7e2693-aa97-4f54-97cc-8cc3bdd5d130}"),
                Name = "Penthouse Suite",
                Address = "303 Sky Tower, Los Angeles, CA",
                Capacity = 5,
                CreatedDate = DateTime.Today.AddDays(15),
                CategoryId = appartamentsGuid,
                IsHotProposition = true,
                ShortDescription = "Luxury penthouse with a private rooftop terrace.",
                LongDescription = "A luxurious penthouse in the Sky Tower, featuring a spacious living room with panoramic Los Angeles views, a modern kitchen, and a private rooftop terrace. The perfect escape for those seeking privacy, elegance, and breathtaking city views.",
                ImgUrl = "https://ikosresorts.com/wp-content/uploads/2024/03/IKOS-ANDALUSIA-DELUXE-2-BEDROOM-PENTHOUSE-SUITE-SEA-VIEW_Living-Room_2880x1745-scaled.jpg",
                Price = 50000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{b3b8f3d5-9efe-497a-9454-d2d16965cfa0}"),
                Name = "Suburban Retreat",
                Address = "121 Oak Street, Dallas, TX",
                Capacity = 6,
                CreatedDate = DateTime.Today.AddDays(20),
                CategoryId = appartamentsGuid,
                IsHotProposition = false,
                ShortDescription = "Cozy and spacious apartment in a quiet suburban area.",
                LongDescription = "A cozy and spacious apartment in a quiet suburban area, perfect for families or groups. Surrounded by greenery, it offers a peaceful atmosphere with modern amenities, just a short drive from Dallas.",
                ImgUrl = "https://cooganslandscape.com/wp-content/uploads/2018/05/cs_suburban-retreat_02.jpg",
                Price = 18000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{ff38ccf6-d319-40d1-8869-c7ae8a415f5e}"),
                Name = "Luxury Villa",
                Address = "45 Palm Street, Beverly Hills, CA",
                Capacity = 8,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = villaGuid,
                IsHotProposition = true,
                ShortDescription = "Spacious villa with a private pool and garden.",
                LongDescription = "An opulent villa in Beverly Hills with a private pool, expansive garden, and elegant terraces. Ideal for those seeking a luxurious retreat with privacy and easy access to upscale shopping and dining.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/166987475.jpg?k=8dc75e9a7e77e2c381d8dd40607a11cc139063f9fa83cb290b0780ea0d36b134&o=&hp=1",
                Price = 75000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{e3132a60-2e38-4366-b0ac-59d653e3400f}"),
                Name = "Mountain Villa",
                Address = "22 Hilltop Ave, Aspen, CO",
                Capacity = 7,
                CreatedDate = DateTime.Today.AddDays(12),
                CategoryId = villaGuid,
                IsHotProposition = false,
                ShortDescription = "A serene villa with panoramic mountain views.",
                LongDescription = "A serene villa in Aspen with panoramic mountain views. Perfect for those looking for a peaceful escape, combining elegance with comfort in a breathtaking natural setting.",
                ImgUrl = "https://i.pinimg.com/736x/e6/70/75/e6707559c50325571f27b7b7854f0812.jpg",
                Price = 55000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{826dace9-c0ba-40b2-bd92-41f9d6519a08}"),
                Name = "Beachfront Villa",
                Address = "15 Ocean Blvd, Malibu, CA",
                Capacity = 6,
                CreatedDate = DateTime.Today.AddDays(18),
                CategoryId = villaGuid,
                IsHotProposition = true,
                ShortDescription = "Elegant beachfront villa with stunning ocean views.",
                LongDescription = "Situated right on the oceanfront, this villa provides unforgettable views and direct beach access. Its elegant design and luxurious amenities create an atmosphere of pure relaxation.",
                ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQoTwfzqd1cqiVQ160798aa9akDS16tqx3WiA&s",
                Price = 75000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{e7136862-7c13-4a57-a05f-e09b9ae98d06}"),
                Name = "Garden Villa",
                Address = "30 Green Lane, San Francisco, CA",
                Capacity = 5,
                CreatedDate = DateTime.Today.AddDays(25),
                CategoryId = villaGuid,
                IsHotProposition = false,
                ShortDescription = "Charming villa with a beautiful private garden.",
                LongDescription = "An elegant beachfront villa offering stunning ocean views and direct beach access. Designed for relaxation, it features a modern living area, large terraces, and world-class amenities.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/126789518.jpg?k=408ac13d6f98710a36962e3eef601f42f8bb889fc06f3c37ed5aed2c0ac1668b&o=&hp=1",
                Price = 50000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{eac0f796-b80d-43ff-800e-dfbe0a5dbb60}"),
                Name = "Mountain Chalet",
                Address = "89 Alpine Road, Aspen, CO",
                Capacity = 6,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = chaletGuid,
                IsHotProposition = true,
                ShortDescription = "Charming chalet located near the ski slopes.",
                LongDescription = "A charming villa in San Francisco with a private garden, offering tranquility and connection with nature. The perfect retreat for families or a romantic getaway.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/341395058.jpg?k=8feed4d0fbeb5e5d5c21a6738a5e196e7020a91156ac49a4b858ffa2f28296bb&o=&hp=1",
                Price = 30000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{97b5de46-c8fa-42ff-b752-e1baaf09a844}"),
                Name = "Lakeside Chalet",
                Address = "8 Pine Hill Rd, Lake Tahoe, CA",
                Capacity = 5,
                CreatedDate = DateTime.Today.AddDays(8),
                CategoryId = chaletGuid,
                IsHotProposition = false,
                ShortDescription = "Chalet by the lake with beautiful forest surroundings.",
                LongDescription = "A cozy chalet near Aspen’s ski slopes, combining traditional alpine style with modern comfort. Ideal for winter sports enthusiasts or those seeking a mountain escape.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/344315015.jpg?k=b521cb84b76ad6348350e4547963a6191c7a7a9758384ba5dea2ee1c270ea0b8&o=&hp=1",
                Price = 35000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{90bea0a5-4dc5-4461-a6ca-ec2633ce4acf}"),
                Name = "Forest Chalet",
                Address = "25 Forest Road, Whistler, BC",
                Capacity = 4,
                CreatedDate = DateTime.Today.AddDays(16),
                CategoryId = chaletGuid,
                IsHotProposition = true,
                ShortDescription = "Rustic chalet nestled in the forest, offering a peaceful retreat.",
                LongDescription = "A cozy chalet nestled in the heart of the forest, ideal for a romantic retreat or a peaceful escape. The serene natural surroundings provide an unforgettable experience.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/166571658.jpg?k=f650daa2d249b002682dddd40bb83a47c1c534e03b7b48b579aa81d3c9735fec&o=&hp=1",
                Price = 37500
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{cdd387fe-0834-494b-9a63-2a622375d36c}"),
                Name = "Winter Chalet",
                Address = "30 Snowy Peak Ave, Zermatt, CH",
                Capacity = 8,
                CreatedDate = DateTime.Today.AddDays(20),
                CategoryId = chaletGuid,
                IsHotProposition = false,
                ShortDescription = "Perfect for skiing enthusiasts, this chalet is located near top ski resorts.",
                LongDescription = "This cozy winter chalet offers an unforgettable stay for skiing enthusiasts, nestled in the heart of Zermatt. With breathtaking views of the snow-capped mountains and proximity to the best ski resorts, it's the perfect escape for those seeking adventure and relaxation. The chalet features a spacious living area, modern amenities, and a warm, inviting atmosphere.",
                ImgUrl = "https://myhome.at/wp-content/uploads/2021/12/ian-keefe-OgcJIKRnRC8-unsplash-scaled-e1657608875630-830x514.jpg",
                Price = 50000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{dcbbfc78-9191-4ced-97c6-da3c51b1adae}"),
                Name = "Cozy Cottage",
                Address = "12 Countryside Lane, Vermont, VT",
                Capacity = 5,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = cottageGuid,
                IsHotProposition = true,
                ShortDescription = "Peaceful cottage surrounded by nature.",
                LongDescription = "Nestled in the serene countryside of Vermont, this cozy cottage is ideal for those looking to escape the hustle and bustle of everyday life. Surrounded by nature, it provides a peaceful retreat with easy access to nearby trails and quaint villages. Perfect for a quiet weekend getaway or a longer stay to recharge.",
                ImgUrl = "https://img.freepik.com/premium-photo/portrayal-peaceful-cottage-surrounded-by-nature-using-warm-comforting-colors_181667-39977.jpg",
                Price = 18000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{48f6d005-6237-465c-a413-e2924e9773e8}"),
                Name = "Forest Cottage",
                Address = "14 Pinewood Rd, Asheville, NC",
                Capacity = 4,
                CreatedDate = DateTime.Today.AddDays(30),
                CategoryId = cottageGuid,
                IsHotProposition = false,
                ShortDescription = "Charming cottage surrounded by lush greenery and trees.",
                LongDescription = "Located in the heart of Asheville, NC, this charming forest cottage is a sanctuary surrounded by lush trees and wildlife. It provides the perfect balance of comfort and nature, with a cozy interior and scenic outdoor space for relaxation. Whether you're an outdoor enthusiast or simply in need of a peaceful escape, this cottage has it all.",
                ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUacp1F7dYO4ZMtPX5Uy5omf2y1_Tz-mjV9Q&s",
                Price = 16000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{70adcfec-32f1-4ae7-a67a-a1690c5ffaa9}"),
                Name = "Riverside Cottage",
                Address = "22 Riverbank Dr, Jackson, WY",
                Capacity = 6,
                CreatedDate = DateTime.Today.AddDays(36),
                CategoryId = cottageGuid,
                IsHotProposition = true,
                ShortDescription = "A beautiful cottage next to a peaceful river.",
                LongDescription = "Escape to tranquility in this riverside cottage, offering a stunning view of the peaceful river that runs just outside. Perfect for nature lovers, it combines rustic charm with modern amenities. Enjoy the soothing sounds of the river while sipping your morning coffee, or spend your days hiking and exploring the nearby area.",
                ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcREH3Bw3qjBoMHcGu989hceIjNCNTn0GRGcuA&s",
                Price = 21000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{0ff2a035-d55d-422c-a7c0-6a3eb4a2b51a}"),
                Name = "Seaside Cottage",
                Address = "5 Ocean View St, Cape Cod, MA",
                Capacity = 4,
                CreatedDate = DateTime.Today.AddDays(50),
                CategoryId = cottageGuid,
                IsHotProposition = false,
                ShortDescription = "Cozy seaside cottage perfect for a relaxing getaway.",
                LongDescription = "This charming seaside cottage provides a perfect retreat for anyone looking to unwind by the ocean. With stunning views, soft sandy beaches, and a peaceful environment, it's an idyllic place to relax and enjoy nature. Whether you're interested in exploring the local area or simply soaking up the sun, this cozy cottage offers a welcoming escape.",
                ImgUrl = "https://media.istockphoto.com/id/539151605/photo/village.jpg?s=612x612&w=0&k=20&c=i1956HGGH6KL_p8uZehqHSInxNzwV9BwYTmoc8lHqC4=",
                Price = 1900
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{9ebd806d-08e7-40d6-9dc8-408c590c119d}"),
                Name = "Glamping Paradise",
                Address = "77 Desert Oasis, Joshua Tree, CA",
                Capacity = 2,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = glampingGuid,
                IsHotProposition = false,
                ShortDescription = "Luxury glamping experience under the stars.",
                LongDescription = "Experience luxury camping like never before in this glamping paradise. Located in the beautiful desert, this unique accommodation allows you to sleep under the stars while still enjoying modern comforts. Perfect for those seeking adventure without compromising on comfort, it offers a memorable escape from the everyday.",
                ImgUrl = "https://images.squarespace-cdn.com/content/v1/65a12f7fd4021742aad7a454/f0a80575-93a1-4ffd-9c1c-e09cdac449d0/unnamed.jpg",
                Price = 2000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{f0aefde0-bc3d-4cfc-b477-00b3ddec847c}"),
                Name = "Forest Tent",
                Address = "9 Forest Trail, Oregon, OR",
                Capacity = 4,
                CreatedDate = DateTime.Today.AddDays(6),
                CategoryId = glampingGuid,
                IsHotProposition = false,
                ShortDescription = "Comfortable tent in the middle of a serene forest.",
                LongDescription = "Immerse yourself in nature with this comfortable forest tent, located in a serene, peaceful forest setting. Offering the best of both worlds—camping's connection with nature and the luxury of a cozy tent—it’s the ideal choice for anyone seeking a more immersive outdoor experience without sacrificing comfort.",
                ImgUrl = "https://hipcamp-res.cloudinary.com/images/c_limit,f_auto,h_1200,q_60,w_1920/v1623141528/campground-photos/ppury203ptsjwa3xaori/a-tent-in-the-forest-tent-in-the-forest-kin-kin-qld-sunshine-coast-glamping-canvas-tent-bell-tent.jpg",
                Price = 2200
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{965155a6-8b18-45e9-9a60-b92b7876fa69}"),
                Name = "Mountain Glamping",
                Address = "19 Hilltop Rd, Colorado, CO",
                Capacity = 3,
                CreatedDate = DateTime.Today.AddDays(14),
                CategoryId = glampingGuid,
                IsHotProposition = true,
                ShortDescription = "Glamping site with breathtaking mountain views.",
                LongDescription = "Set atop a stunning mountain, this glamping site offers panoramic views of the surrounding landscape. With modern, luxurious tents, this is the perfect way to experience the beauty of nature without sacrificing the comforts of home. Ideal for adventure-seekers and those looking to reconnect with the outdoors.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/268933268.jpg?k=31035bb853f6356e1edab72d633e887d0dc18f24bb18d45ff7392a8f95c21431&o=&hp=1",
                Price = 2800
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{9015220b-2e8d-4067-a5cb-9a556260e1da}"),
                Name = "Beach Glamping",
                Address = "10 Beachfront Ave, Florida, FL",
                Capacity = 2,
                CreatedDate = DateTime.Today.AddDays(28),
                CategoryId = glampingGuid,
                IsHotProposition = false,
                ShortDescription = "Exclusive glamping experience by the beach.",
                LongDescription = "Enjoy the ultimate beachside escape with this exclusive glamping experience. Situated right on the sand, it offers unparalleled views of the ocean and the soothing sounds of the waves. Perfect for those looking to combine adventure and relaxation in a unique, luxurious way.",
                ImgUrl = "https://epicexcursionsnc.com/wp-content/uploads/sites/5139/2021/12/Ultimate-Island-Glamping-Experience-image-1.jpg?resize=360%2C240&zoom=2",
                Price = 2400
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{4cbafdc3-446b-4ab3-bf2c-2c0b3c744492}"),
                Name = "Budget Hostel",
                Address = "25 Backpacker Lane, Prague, CZ",
                Capacity = 12,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = hostelGuid,
                IsHotProposition = true,
                ShortDescription = "Affordable hostel for travelers with a social vibe.",
                LongDescription = "This affordable hostel provides budget travelers with a comfortable place to stay while enjoying a social, friendly atmosphere. Located in the heart of Prague, it’s within walking distance of key attractions, making it ideal for those who want to explore the city without breaking the bank.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/215321123.jpg?k=424cc4139871d8c2b6ca4f825afcc94002327662e8268afce3776159d0e241a0&o=&hp=1",
                Price = 4000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{3abf0f37-8079-4900-bd6b-8679585a5607}"),
                Name = "City Hostel",
                Address = "8 Urban Street, Berlin, DE",
                Capacity = 10,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = hostelGuid,
                IsHotProposition = false,
                ShortDescription = "Convenient city hostel with easy access to tourist attractions.",
                LongDescription = "Conveniently located in the bustling city of Berlin, this hostel offers easy access to the city's major tourist attractions. Whether you're here for business or leisure, you'll appreciate the modern amenities, comfortable rooms, and vibrant atmosphere of this well-located hostel.",
                ImgUrl = "https://lviv-city-hostel.nochi.com.ua/data/Photos/OriginalPhoto/2478/247894/247894309/Lviv-City-Hostel-Room.JPEG",
                Price = 3500
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{cf0e7c96-b60b-4c6b-8374-57f827fa17a4}"),
                Name = "Cozy Backpacker Hostel",
                Address = "18 Mountain View Road, Sydney, AU",
                Capacity = 8,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = hostelGuid,
                IsHotProposition = true,
                ShortDescription = "Simple yet cozy hostel for budget travelers.",
                LongDescription = "Located in a peaceful area of Sydney, this cozy backpacker hostel is the perfect place for travelers seeking both affordability and comfort. With a friendly environment and easy access to local attractions, it's the ideal home base for exploring the city.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/158775758.jpg?k=31bb0155b48892515927e82f2434205cb82299eae53f10723a8b398da8640aec&o=&hp=1",
                Price = 4500
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{c119661c-1d5a-42c1-8819-6b0885af4d4a}"),
                Name = "Beachfront Hostel",
                Address = "2 Ocean Blvd, Lisbon, PT",
                Capacity = 15,
                CreatedDate = DateTime.Today.AddDays(20),
                CategoryId = hostelGuid,
                IsHotProposition = false,
                ShortDescription = "Hostel right by the beach for travelers seeking relaxation.",
                LongDescription = "Situated right by the beach, this hostel is perfect for travelers seeking a laid-back, relaxing experience. Enjoy breathtaking views, easy access to the beach, and a comfortable environment that makes it an ideal spot to rest and unwind after a day of exploring Lisbon.",
                ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmNzZYaVh2l68QWrmsNggJQS1GxxMPO3Iltw&s",
                Price = 5000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{400c5bff-99c3-4493-a618-6653241bc6b5}"),
                Name = "Seaside Camping",
                Address = "9 Ocean View Road, Cape Cod, MA",
                Capacity = 4,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = campingGuid,
                IsHotProposition = true,
                ShortDescription = "Enjoy camping with a view of the ocean.",
                LongDescription = "Immerse yourself in the beauty of nature with this seaside camping experience. Located just steps from the ocean, it offers stunning views, fresh sea air, and a true outdoor adventure. Enjoy the natural surroundings while having all the comforts of a well-equipped campsite.",
                ImgUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/76334100.jpg?k=d369e33cd367722733e61bf38b20ba1fee537abc9b696747ca0e6ae57dc02964&o=&hp=1",
                Price = 6000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{a4e54b1f-3149-4d9b-8d88-e8b4a174a619}"),
                Name = "Mountain Campsite",
                Address = "20 Alpine Trail, Colorado, CO",
                Capacity = 6,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = campingGuid,
                IsHotProposition = false,
                ShortDescription = "Camp amidst towering mountains for a true outdoor experience.",
                LongDescription = "This picturesque mountain campsite offers a true outdoor adventure amidst towering peaks and stunning vistas. Whether you're hiking, fishing, or simply enjoying the fresh mountain air, this campsite is the perfect destination for nature lovers seeking an authentic camping experience.",
                ImgUrl = "https://images.stockcake.com/public/5/c/c/5ccc3dc0-5051-4b2f-bfed-5a9633c5bc67_large/starry-mountain-camping-stockcake.jpg",
                Price = 5500
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{1a491f3d-94ac-4df8-a244-0ef6c4a5c5b2}"),
                Name = "Forest Camp",
                Address = "12 Forest Rd, Oregon, OR",
                Capacity = 8,
                CreatedDate = DateTime.Today.AddDays(42),
                CategoryId = campingGuid,
                IsHotProposition = true,
                ShortDescription = "Secluded campsite in the heart of the forest.",
                LongDescription = "Tucked away in a secluded forest, this campsite provides a peaceful escape from the everyday. With only the sounds of nature surrounding you, it's a perfect spot for those looking to disconnect and enjoy the simplicity of the outdoors. Ideal for camping enthusiasts or those seeking solitude.",
                ImgUrl = "https://q-xx.bstatic.com/xdata/images/hotel/max1024x768/205670362.jpg?k=228d9c931b9f22eb9d7dd1127fc4be9086f3e28e4fce5c4a19ce85c40cc0df1c&o=?s=375x210&ar=16x9",
                Price = 5000
            });

            modelBuilder.Entity<Accommodations>().HasData(new Accommodations
            {
                AccommodationsId = Guid.Parse("{a4ab6df6-66b8-46f7-8198-c94332964006}"),
                Name = "Desert Camping",
                Address = "15 Sand Dune Rd, Nevada, NV",
                Capacity = 5,
                CreatedDate = DateTime.Today.AddDays(24),
                CategoryId = campingGuid,
                IsHotProposition = false,
                ShortDescription = "An adventurous camping experience in the desert.",
                LongDescription = "Experience the vast beauty of the desert with this adventurous camping experience. Surrounded by sweeping sand dunes and starry skies, this unique campsite offers an unforgettable opportunity to immerse yourself in the natural wonders of the desert while enjoying the comfort of a well-equipped camp.",
                ImgUrl = "https://www.hostelworld.com/blog/wp-content/uploads/2023/04/parker-hilton-VtGLcivTXtk-unsplash.jpg",
                Price = 4500
            });

            modelBuilder.Entity<Reservations>().HasData(new Reservations
            {
                ReservationId = Guid.Parse("{c4046135-7ef7-4a85-a125-feeea203d4de}"),
                AccommodationsId = Guid.Parse("{a4ab6df6-66b8-46f7-8198-c94332964006}"),
                UserId = "TestFirstUserId",
                AdditionalServices = "test",
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(7),
                CustomerNote = "test",
                GuestsCount = 4,
            });
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken
            = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Accommodations>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

