using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restino.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedShortAndLongDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Accommodations",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("0ff2a035-d55d-422c-a7c0-6a3eb4a2b51a"),
                column: "LongDescription",
                value: "This charming seaside cottage provides a perfect retreat for anyone looking to unwind by the ocean. With stunning views, soft sandy beaches, and a peaceful environment, it's an idyllic place to relax and enjoy nature. Whether you're interested in exploring the local area or simply soaking up the sun, this cozy cottage offers a welcoming escape.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("1a491f3d-94ac-4df8-a244-0ef6c4a5c5b2"),
                column: "LongDescription",
                value: "Tucked away in a secluded forest, this campsite provides a peaceful escape from the everyday. With only the sounds of nature surrounding you, it's a perfect spot for those looking to disconnect and enjoy the simplicity of the outdoors. Ideal for camping enthusiasts or those seeking solitude.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("3abf0f37-8079-4900-bd6b-8679585a5607"),
                column: "LongDescription",
                value: "Conveniently located in the bustling city of Berlin, this hostel offers easy access to the city's major tourist attractions. Whether you're here for business or leisure, you'll appreciate the modern amenities, comfortable rooms, and vibrant atmosphere of this well-located hostel.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("400c5bff-99c3-4493-a618-6653241bc6b5"),
                column: "LongDescription",
                value: "Immerse yourself in the beauty of nature with this seaside camping experience. Located just steps from the ocean, it offers stunning views, fresh sea air, and a true outdoor adventure. Enjoy the natural surroundings while having all the comforts of a well-equipped campsite.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("47fc830b-751c-4b54-88e3-3281d746f3fd"),
                column: "LongDescription",
                value: "Sunrise Apartments offer the perfect seaside getaway with spacious, modern apartments and stunning ocean views. Each apartment features a cozy living room, fully equipped kitchen, comfortable bedrooms, and a stylish bathroom. Ideal for families or groups looking to enjoy the beach and relaxation.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("48f6d005-6237-465c-a413-e2924e9773e8"),
                column: "LongDescription",
                value: "Located in the heart of Asheville, NC, this charming forest cottage is a sanctuary surrounded by lush trees and wildlife. It provides the perfect balance of comfort and nature, with a cozy interior and scenic outdoor space for relaxation. Whether you're an outdoor enthusiast or simply in need of a peaceful escape, this cottage has it all.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("4cbafdc3-446b-4ab3-bf2c-2c0b3c744492"),
                column: "LongDescription",
                value: "This affordable hostel provides budget travelers with a comfortable place to stay while enjoying a social, friendly atmosphere. Located in the heart of Prague, it’s within walking distance of key attractions, making it ideal for those who want to explore the city without breaking the bank.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("6b7e2693-aa97-4f54-97cc-8cc3bdd5d130"),
                column: "LongDescription",
                value: "A luxurious penthouse in the Sky Tower, featuring a spacious living room with panoramic Los Angeles views, a modern kitchen, and a private rooftop terrace. The perfect escape for those seeking privacy, elegance, and breathtaking city views.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("70adcfec-32f1-4ae7-a67a-a1690c5ffaa9"),
                column: "LongDescription",
                value: "Escape to tranquility in this riverside cottage, offering a stunning view of the peaceful river that runs just outside. Perfect for nature lovers, it combines rustic charm with modern amenities. Enjoy the soothing sounds of the river while sipping your morning coffee, or spend your days hiking and exploring the nearby area.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("826dace9-c0ba-40b2-bd92-41f9d6519a08"),
                column: "LongDescription",
                value: "Situated right on the oceanfront, this villa provides unforgettable views and direct beach access. Its elegant design and luxurious amenities create an atmosphere of pure relaxation.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9015220b-2e8d-4067-a5cb-9a556260e1da"),
                column: "LongDescription",
                value: "Enjoy the ultimate beachside escape with this exclusive glamping experience. Situated right on the sand, it offers unparalleled views of the ocean and the soothing sounds of the waves. Perfect for those looking to combine adventure and relaxation in a unique, luxurious way.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("90bea0a5-4dc5-4461-a6ca-ec2633ce4acf"),
                column: "LongDescription",
                value: "A cozy chalet nestled in the heart of the forest, ideal for a romantic retreat or a peaceful escape. The serene natural surroundings provide an unforgettable experience.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("965155a6-8b18-45e9-9a60-b92b7876fa69"),
                column: "LongDescription",
                value: "Set atop a stunning mountain, this glamping site offers panoramic views of the surrounding landscape. With modern, luxurious tents, this is the perfect way to experience the beauty of nature without sacrificing the comforts of home. Ideal for adventure-seekers and those looking to reconnect with the outdoors.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("97b5de46-c8fa-42ff-b752-e1baaf09a844"),
                column: "LongDescription",
                value: "A cozy chalet near Aspen’s ski slopes, combining traditional alpine style with modern comfort. Ideal for winter sports enthusiasts or those seeking a mountain escape.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9db960f8-38e7-4fb4-8db5-6c82f65a654c"),
                column: "LongDescription",
                value: "This stylish apartment offers large windows with breathtaking views of Chicago's skyline. The modern interior includes a spacious living room, kitchen, and cozy bedrooms, making it perfect for small families or couples who want to experience the vibrant city life.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9ebd806d-08e7-40d6-9dc8-408c590c119d"),
                column: "LongDescription",
                value: "Experience luxury camping like never before in this glamping paradise. Located in the beautiful desert, this unique accommodation allows you to sleep under the stars while still enjoying modern comforts. Perfect for those seeking adventure without compromising on comfort, it offers a memorable escape from the everyday.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("a4ab6df6-66b8-46f7-8198-c94332964006"),
                column: "LongDescription",
                value: "Experience the vast beauty of the desert with this adventurous camping experience. Surrounded by sweeping sand dunes and starry skies, this unique campsite offers an unforgettable opportunity to immerse yourself in the natural wonders of the desert while enjoying the comfort of a well-equipped camp.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("a4e54b1f-3149-4d9b-8d88-e8b4a174a619"),
                column: "LongDescription",
                value: "This picturesque mountain campsite offers a true outdoor adventure amidst towering peaks and stunning vistas. Whether you're hiking, fishing, or simply enjoying the fresh mountain air, this campsite is the perfect destination for nature lovers seeking an authentic camping experience.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("b3b8f3d5-9efe-497a-9454-d2d16965cfa0"),
                column: "LongDescription",
                value: "A cozy and spacious apartment in a quiet suburban area, perfect for families or groups. Surrounded by greenery, it offers a peaceful atmosphere with modern amenities, just a short drive from Dallas.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"),
                column: "LongDescription",
                value: "Situated right by the beach, this hostel is perfect for travelers seeking a laid-back, relaxing experience. Enjoy breathtaking views, easy access to the beach, and a comfortable environment that makes it an ideal spot to rest and unwind after a day of exploring Lisbon.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("cdd387fe-0834-494b-9a63-2a622375d36c"),
                column: "LongDescription",
                value: "This cozy winter chalet offers an unforgettable stay for skiing enthusiasts, nestled in the heart of Zermatt. With breathtaking views of the snow-capped mountains and proximity to the best ski resorts, it's the perfect escape for those seeking adventure and relaxation. The chalet features a spacious living area, modern amenities, and a warm, inviting atmosphere.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("cf0e7c96-b60b-4c6b-8374-57f827fa17a4"),
                column: "LongDescription",
                value: "Located in a peaceful area of Sydney, this cozy backpacker hostel is the perfect place for travelers seeking both affordability and comfort. With a friendly environment and easy access to local attractions, it's the ideal home base for exploring the city.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("dcbbfc78-9191-4ced-97c6-da3c51b1adae"),
                column: "LongDescription",
                value: "Nestled in the serene countryside of Vermont, this cozy cottage is ideal for those looking to escape the hustle and bustle of everyday life. Surrounded by nature, it provides a peaceful retreat with easy access to nearby trails and quaint villages. Perfect for a quiet weekend getaway or a longer stay to recharge.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("e3132a60-2e38-4366-b0ac-59d653e3400f"),
                column: "LongDescription",
                value: "A serene villa in Aspen with panoramic mountain views. Perfect for those looking for a peaceful escape, combining elegance with comfort in a breathtaking natural setting.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("e7136862-7c13-4a57-a05f-e09b9ae98d06"),
                column: "LongDescription",
                value: "An elegant beachfront villa offering stunning ocean views and direct beach access. Designed for relaxation, it features a modern living area, large terraces, and world-class amenities.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("eac0f796-b80d-43ff-800e-dfbe0a5dbb60"),
                column: "LongDescription",
                value: "A charming villa in San Francisco with a private garden, offering tranquility and connection with nature. The perfect retreat for families or a romantic getaway.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("f0aefde0-bc3d-4cfc-b477-00b3ddec847c"),
                column: "LongDescription",
                value: "Immerse yourself in nature with this comfortable forest tent, located in a serene, peaceful forest setting. Offering the best of both worlds—camping's connection with nature and the luxury of a cozy tent—it’s the ideal choice for anyone seeking a more immersive outdoor experience without sacrificing comfort.");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("ff38ccf6-d319-40d1-8869-c7ae8a415f5e"),
                column: "LongDescription",
                value: "An opulent villa in Beverly Hills with a private pool, expansive garden, and elegant terraces. Ideal for those seeking a luxurious retreat with privacy and easy access to upscale shopping and dining.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Accommodations");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Accommodations",
                newName: "Description");
        }
    }
}
