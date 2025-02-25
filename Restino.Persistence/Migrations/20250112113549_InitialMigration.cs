using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restino.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoriesId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderPrice = table.Column<int>(type: "int", nullable: false),
                    OrderCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrdersId);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    AccommodationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsHotProposition = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.AccommodationsId);
                    table.ForeignKey(
                        name: "FK_Accommodations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoriesId", "CategoryName", "Description", "ImgUrl" },
                values: new object[,]
                {
                    { new Guid("418ade5f-d0b7-4545-b9de-beafbefffa66"), "Chalet", "A chalet is a traditional mountain house made of wood with a warm and cozy interior. They are most commonly found in mountainous regions and are popular among winter sports enthusiasts. Chalets are ideal for family vacations or romantic getaways. The ambiance of these homes promotes complete relaxation, while fireplaces add a touch of coziness on cold winter evenings.", "https://cdn.pixabay.com/photo/2019/12/11/12/00/mountain-4688203_1280.jpg" },
                    { new Guid("6f80d6e0-54b3-495d-847b-16a092c8b626"), "Camping", "Camping is a way to spend time in nature by staying in tents or trailers. It’s a great opportunity to escape civilization, enjoying quiet mornings and starry nights. Campsites are often located near forests, rivers, or mountains, providing opportunities for active leisure such as fishing, hiking, or cycling.", "https://cdn.pixabay.com/photo/2017/08/17/08/08/camp-2650359_1280.jpg" },
                    { new Guid("8f67819c-0d09-43e8-b64f-17c9123b6040"), "Villa", "A villa is a luxurious house typically situated in a picturesque area. It is perfect for large groups or families. Villas come equipped with spacious rooms, terraces, swimming pools, and sometimes even gardens. This type of accommodation is designed for those seeking privacy, comfort, and natural beauty. It’s an excellent choice for hosting parties or enjoying a peaceful retreat away from the hustle and bustle of the city.", "https://cdn.pixabay.com/photo/2013/10/12/18/05/villa-194671_1280.jpg" },
                    { new Guid("9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a"), "Hostel", "A hostel is a budget-friendly accommodation option for travelers. Typically, it features shared rooms with individual beds, although private rooms are also available. Hostels are ideal for young people and those looking to meet fellow travelers. They often include shared kitchens, common areas, and are usually located in city centers.", "https://cdn.pixabay.com/photo/2013/06/30/19/07/bed-142516_1280.jpg" },
                    { new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"), "Appartaments", "Apartments are a modern type of accommodation that combines the comfort of a home with high-quality service. They are ideal for short-term or long-term stays, offering a fully equipped kitchen, spacious interiors, and modern amenities. Apartments are often located in city centers, providing easy access to popular locations. Choosing apartments ensures independence and comfort for travelers who value coziness and the convenience of a private space.", "https://cdn.pixabay.com/photo/2016/11/30/08/48/bedroom-1872196_1280.jpg" },
                    { new Guid("cf0976f2-83c1-4708-afea-3e4785db6d66"), "Cottage", "A cottage is a small country house offering peace and coziness away from the city noise. It usually features a traditional design with modern amenities. Cottages are perfect for family vacations or short getaways into nature. They are often located near forests or lakes, creating ideal conditions for outdoor activities.", "https://cdn.pixabay.com/photo/2015/08/25/14/16/small-wooden-house-906912_1280.jpg" },
                    { new Guid("d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d"), "Glamping", "Glamping is a combination of luxury and closeness to nature. This type of accommodation offers tents or wooden cabins with all modern conveniences. Glamping provides an authentic outdoor experience without sacrificing comfort. It is perfect for those who love nature but prefer a more luxurious stay.", "https://cdn.pixabay.com/photo/2021/07/25/06/26/glamping-6490987_1280.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "AccommodationsId", "Address", "Capacity", "CategoryId", "CreatedBy", "CreatedDate", "Description", "ImgUrl", "IsHotProposition", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0ff2a035-d55d-422c-a7c0-6a3eb4a2b51a"), "5 Ocean View St, Cape Cod, MA", 4, new Guid("cf0976f2-83c1-4708-afea-3e4785db6d66"), null, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Local), "Cozy seaside cottage perfect for a relaxing getaway.", "https://media.istockphoto.com/id/539151605/photo/village.jpg?s=612x612&w=0&k=20&c=i1956HGGH6KL_p8uZehqHSInxNzwV9BwYTmoc8lHqC4=", false, null, null, "Seaside Cottage", 1900 },
                    { new Guid("1a491f3d-94ac-4df8-a244-0ef6c4a5c5b2"), "12 Forest Rd, Oregon, OR", 8, new Guid("6f80d6e0-54b3-495d-847b-16a092c8b626"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Secluded campsite in the heart of the forest.", "https://q-xx.bstatic.com/xdata/images/hotel/max1024x768/205670362.jpg?k=228d9c931b9f22eb9d7dd1127fc4be9086f3e28e4fce5c4a19ce85c40cc0df1c&o=?s=375x210&ar=16x9", true, null, null, "Forest Camp", 5000 },
                    { new Guid("3abf0f37-8079-4900-bd6b-8679585a5607"), "8 Urban Street, Berlin, DE", 10, new Guid("9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Convenient city hostel with easy access to tourist attractions.", "https://lviv-city-hostel.nochi.com.ua/data/Photos/OriginalPhoto/2478/247894/247894309/Lviv-City-Hostel-Room.JPEG", false, null, null, "City Hostel", 3500 },
                    { new Guid("400c5bff-99c3-4493-a618-6653241bc6b5"), "9 Ocean View Road, Cape Cod, MA", 4, new Guid("6f80d6e0-54b3-495d-847b-16a092c8b626"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Enjoy camping with a view of the ocean.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/76334100.jpg?k=d369e33cd367722733e61bf38b20ba1fee537abc9b696747ca0e6ae57dc02964&o=&hp=1", true, null, null, "Seaside Camping", 6000 },
                    { new Guid("47fc830b-751c-4b54-88e3-3281d746f3fd"), "123 Beachside Ave, Miami, FL", 4, new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Cozy apartments with a sea view and modern amenities.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/397741258.jpg?k=225b07468ede098c5df3b7037eaa6b681dd01f94d392a0bb96827f4467515fdd&o=&hp=1", false, null, null, "Sunrise Apartments", 12000 },
                    { new Guid("48f6d005-6237-465c-a413-e2924e9773e8"), "14 Pinewood Rd, Asheville, NC", 4, new Guid("cf0976f2-83c1-4708-afea-3e4785db6d66"), null, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Local), "Charming cottage surrounded by lush greenery and trees.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUacp1F7dYO4ZMtPX5Uy5omf2y1_Tz-mjV9Q&s", false, null, null, "Forest Cottage", 16000 },
                    { new Guid("4cbafdc3-446b-4ab3-bf2c-2c0b3c744492"), "25 Backpacker Lane, Prague, CZ", 12, new Guid("9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Affordable hostel for travelers with a social vibe.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/215321123.jpg?k=424cc4139871d8c2b6ca4f825afcc94002327662e8268afce3776159d0e241a0&o=&hp=1", true, null, null, "Budget Hostel", 4000 },
                    { new Guid("6b7e2693-aa97-4f54-97cc-8cc3bdd5d130"), "303 Sky Tower, Los Angeles, CA", 5, new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"), null, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Local), "Luxury penthouse with a private rooftop terrace.", "https://ikosresorts.com/wp-content/uploads/2024/03/IKOS-ANDALUSIA-DELUXE-2-BEDROOM-PENTHOUSE-SUITE-SEA-VIEW_Living-Room_2880x1745-scaled.jpg", true, null, null, "Penthouse Suite", 50000 },
                    { new Guid("70adcfec-32f1-4ae7-a67a-a1690c5ffaa9"), "22 Riverbank Dr, Jackson, WY", 6, new Guid("cf0976f2-83c1-4708-afea-3e4785db6d66"), null, new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Local), "A beautiful cottage next to a peaceful river.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcREH3Bw3qjBoMHcGu989hceIjNCNTn0GRGcuA&s", true, null, null, "Riverside Cottage", 21000 },
                    { new Guid("826dace9-c0ba-40b2-bd92-41f9d6519a08"), "15 Ocean Blvd, Malibu, CA", 6, new Guid("8f67819c-0d09-43e8-b64f-17c9123b6040"), null, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Local), "Elegant beachfront villa with stunning ocean views.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQoTwfzqd1cqiVQ160798aa9akDS16tqx3WiA&s", true, null, null, "Beachfront Villa", 75000 },
                    { new Guid("9015220b-2e8d-4067-a5cb-9a556260e1da"), "10 Beachfront Ave, Florida, FL", 2, new Guid("d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d"), null, new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Local), "Exclusive glamping experience by the beach.", "https://epicexcursionsnc.com/wp-content/uploads/sites/5139/2021/12/Ultimate-Island-Glamping-Experience-image-1.jpg?resize=360%2C240&zoom=2", false, null, null, "Beach Glamping", 2400 },
                    { new Guid("90bea0a5-4dc5-4461-a6ca-ec2633ce4acf"), "25 Forest Road, Whistler, BC", 4, new Guid("418ade5f-d0b7-4545-b9de-beafbefffa66"), null, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Local), "Rustic chalet nestled in the forest, offering a peaceful retreat.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/166571658.jpg?k=f650daa2d249b002682dddd40bb83a47c1c534e03b7b48b579aa81d3c9735fec&o=&hp=1", true, null, null, "Forest Chalet", 37500 },
                    { new Guid("965155a6-8b18-45e9-9a60-b92b7876fa69"), "19 Hilltop Rd, Colorado, CO", 3, new Guid("d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d"), null, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), "Glamping site with breathtaking mountain views.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/268933268.jpg?k=31035bb853f6356e1edab72d633e887d0dc18f24bb18d45ff7392a8f95c21431&o=&hp=1", true, null, null, "Mountain Glamping", 2800 },
                    { new Guid("97b5de46-c8fa-42ff-b752-e1baaf09a844"), "8 Pine Hill Rd, Lake Tahoe, CA", 5, new Guid("418ade5f-d0b7-4545-b9de-beafbefffa66"), null, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Local), "Chalet by the lake with beautiful forest surroundings.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/344315015.jpg?k=b521cb84b76ad6348350e4547963a6191c7a7a9758384ba5dea2ee1c270ea0b8&o=&hp=1", false, null, null, "Lakeside Chalet", 35000 },
                    { new Guid("9db960f8-38e7-4fb4-8db5-6c82f65a654c"), "98 Main Blvd, Chicago, IL", 3, new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"), null, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Local), "Stylish apartment with a stunning view of the city skyline.", "https://images.stockcake.com/public/8/8/1/8814dc5c-08e3-48f6-be0a-287e67513bf8_large/city-view-apartment-stockcake.jpg", false, null, null, "City View Apartment", 22000 },
                    { new Guid("9ebd806d-08e7-40d6-9dc8-408c590c119d"), "77 Desert Oasis, Joshua Tree, CA", 2, new Guid("d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Luxury glamping experience under the stars.", "https://images.squarespace-cdn.com/content/v1/65a12f7fd4021742aad7a454/f0a80575-93a1-4ffd-9c1c-e09cdac449d0/unnamed.jpg", false, null, null, "Glamping Paradise", 2000 },
                    { new Guid("a4ab6df6-66b8-46f7-8198-c94332964006"), "15 Sand Dune Rd, Nevada, NV", 5, new Guid("6f80d6e0-54b3-495d-847b-16a092c8b626"), null, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "An adventurous camping experience in the desert.", "https://www.hostelworld.com/blog/wp-content/uploads/2023/04/parker-hilton-VtGLcivTXtk-unsplash.jpg", false, null, null, "Desert Camping", 4500 },
                    { new Guid("a4e54b1f-3149-4d9b-8d88-e8b4a174a619"), "20 Alpine Trail, Colorado, CO", 6, new Guid("6f80d6e0-54b3-495d-847b-16a092c8b626"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Camp amidst towering mountains for a true outdoor experience.", "https://images.stockcake.com/public/5/c/c/5ccc3dc0-5051-4b2f-bfed-5a9633c5bc67_large/starry-mountain-camping-stockcake.jpg", false, null, null, "Mountain Campsite", 5500 },
                    { new Guid("b3b8f3d5-9efe-497a-9454-d2d16965cfa0"), "121 Oak Street, Dallas, TX", 6, new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"), null, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), "Cozy and spacious apartment in a quiet suburban area.", "https://cooganslandscape.com/wp-content/uploads/2018/05/cs_suburban-retreat_02.jpg", false, null, null, "Suburban Retreat", 18000 },
                    { new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"), "2 Ocean Blvd, Lisbon, PT", 15, new Guid("9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a"), null, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), "Hostel right by the beach for travelers seeking relaxation.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmNzZYaVh2l68QWrmsNggJQS1GxxMPO3Iltw&s", false, null, null, "Beachfront Hostel", 5000 },
                    { new Guid("cdd387fe-0834-494b-9a63-2a622375d36c"), "30 Snowy Peak Ave, Zermatt, CH", 8, new Guid("418ade5f-d0b7-4545-b9de-beafbefffa66"), null, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), "Perfect for skiing enthusiasts, this chalet is located near top ski resorts.", "https://myhome.at/wp-content/uploads/2021/12/ian-keefe-OgcJIKRnRC8-unsplash-scaled-e1657608875630-830x514.jpg", false, null, null, "Winter Chalet", 50000 },
                    { new Guid("cf0e7c96-b60b-4c6b-8374-57f827fa17a4"), "18 Mountain View Road, Sydney, AU", 8, new Guid("9fbd8bb8-1a85-4305-87fd-4b3d011b1a5a"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Simple yet cozy hostel for budget travelers.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/158775758.jpg?k=31bb0155b48892515927e82f2434205cb82299eae53f10723a8b398da8640aec&o=&hp=1", true, null, null, "Cozy Backpacker Hostel", 4500 },
                    { new Guid("dcbbfc78-9191-4ced-97c6-da3c51b1adae"), "12 Countryside Lane, Vermont, VT", 5, new Guid("cf0976f2-83c1-4708-afea-3e4785db6d66"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Peaceful cottage surrounded by nature.", "https://img.freepik.com/premium-photo/portrayal-peaceful-cottage-surrounded-by-nature-using-warm-comforting-colors_181667-39977.jpg", true, null, null, "Cozy Cottage", 18000 },
                    { new Guid("e3132a60-2e38-4366-b0ac-59d653e3400f"), "22 Hilltop Ave, Aspen, CO", 7, new Guid("8f67819c-0d09-43e8-b64f-17c9123b6040"), null, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Local), "A serene villa with panoramic mountain views.", "https://i.pinimg.com/736x/e6/70/75/e6707559c50325571f27b7b7854f0812.jpg", false, null, null, "Mountain Villa", 55000 },
                    { new Guid("e7136862-7c13-4a57-a05f-e09b9ae98d06"), "30 Green Lane, San Francisco, CA", 5, new Guid("8f67819c-0d09-43e8-b64f-17c9123b6040"), null, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), "Charming villa with a beautiful private garden.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/126789518.jpg?k=408ac13d6f98710a36962e3eef601f42f8bb889fc06f3c37ed5aed2c0ac1668b&o=&hp=1", false, null, null, "Garden Villa", 50000 },
                    { new Guid("eac0f796-b80d-43ff-800e-dfbe0a5dbb60"), "89 Alpine Road, Aspen, CO", 6, new Guid("418ade5f-d0b7-4545-b9de-beafbefffa66"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Charming chalet located near the ski slopes.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/341395058.jpg?k=8feed4d0fbeb5e5d5c21a6738a5e196e7020a91156ac49a4b858ffa2f28296bb&o=&hp=1", true, null, null, "Mountain Chalet", 30000 },
                    { new Guid("f0aefde0-bc3d-4cfc-b477-00b3ddec847c"), "9 Forest Trail, Oregon, OR", 4, new Guid("d1e68fb1-9cd9-4018-9ba5-cfb9bd315b0d"), null, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Local), "Comfortable tent in the middle of a serene forest.", "https://hipcamp-res.cloudinary.com/images/c_limit,f_auto,h_1200,q_60,w_1920/v1623141528/campground-photos/ppury203ptsjwa3xaori/a-tent-in-the-forest-tent-in-the-forest-kin-kin-qld-sunshine-coast-glamping-canvas-tent-bell-tent.jpg", false, null, null, "Forest Tent", 2200 },
                    { new Guid("ff38ccf6-d319-40d1-8869-c7ae8a415f5e"), "45 Palm Street, Beverly Hills, CA", 8, new Guid("8f67819c-0d09-43e8-b64f-17c9123b6040"), null, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Local), "Spacious villa with a private pool and garden.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/166987475.jpg?k=8dc75e9a7e77e2c381d8dd40607a11cc139063f9fa83cb290b0780ea0d36b134&o=&hp=1", true, null, null, "Luxury Villa", 75000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_CategoryId",
                table: "Accommodations",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
