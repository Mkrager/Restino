using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restino.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("0ff2a035-d55d-422c-a7c0-6a3eb4a2b51a"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("1a491f3d-94ac-4df8-a244-0ef6c4a5c5b2"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("3abf0f37-8079-4900-bd6b-8679585a5607"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("400c5bff-99c3-4493-a618-6653241bc6b5"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("47fc830b-751c-4b54-88e3-3281d746f3fd"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("48f6d005-6237-465c-a413-e2924e9773e8"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("4cbafdc3-446b-4ab3-bf2c-2c0b3c744492"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("6b7e2693-aa97-4f54-97cc-8cc3bdd5d130"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("70adcfec-32f1-4ae7-a67a-a1690c5ffaa9"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("826dace9-c0ba-40b2-bd92-41f9d6519a08"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9015220b-2e8d-4067-a5cb-9a556260e1da"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("90bea0a5-4dc5-4461-a6ca-ec2633ce4acf"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("965155a6-8b18-45e9-9a60-b92b7876fa69"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("97b5de46-c8fa-42ff-b752-e1baaf09a844"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9db960f8-38e7-4fb4-8db5-6c82f65a654c"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9ebd806d-08e7-40d6-9dc8-408c590c119d"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("a4ab6df6-66b8-46f7-8198-c94332964006"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("a4e54b1f-3149-4d9b-8d88-e8b4a174a619"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("b3b8f3d5-9efe-497a-9454-d2d16965cfa0"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("cdd387fe-0834-494b-9a63-2a622375d36c"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("cf0e7c96-b60b-4c6b-8374-57f827fa17a4"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("dcbbfc78-9191-4ced-97c6-da3c51b1adae"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("e3132a60-2e38-4366-b0ac-59d653e3400f"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("e7136862-7c13-4a57-a05f-e09b9ae98d06"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("eac0f796-b80d-43ff-800e-dfbe0a5dbb60"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("f0aefde0-bc3d-4cfc-b477-00b3ddec847c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("ff38ccf6-d319-40d1-8869-c7ae8a415f5e"),
                column: "CreatedDate",
                value: new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ReservationId",
                keyValue: new Guid("c4046135-7ef7-4a85-a125-feeea203d4de"),
                columns: new[] { "CheckInDate", "CheckOutDate", "UserId" },
                values: new object[] { new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Local), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("0ff2a035-d55d-422c-a7c0-6a3eb4a2b51a"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("1a491f3d-94ac-4df8-a244-0ef6c4a5c5b2"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("3abf0f37-8079-4900-bd6b-8679585a5607"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("400c5bff-99c3-4493-a618-6653241bc6b5"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("47fc830b-751c-4b54-88e3-3281d746f3fd"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("48f6d005-6237-465c-a413-e2924e9773e8"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("4cbafdc3-446b-4ab3-bf2c-2c0b3c744492"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("6b7e2693-aa97-4f54-97cc-8cc3bdd5d130"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("70adcfec-32f1-4ae7-a67a-a1690c5ffaa9"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("826dace9-c0ba-40b2-bd92-41f9d6519a08"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9015220b-2e8d-4067-a5cb-9a556260e1da"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("90bea0a5-4dc5-4461-a6ca-ec2633ce4acf"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("965155a6-8b18-45e9-9a60-b92b7876fa69"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("97b5de46-c8fa-42ff-b752-e1baaf09a844"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9db960f8-38e7-4fb4-8db5-6c82f65a654c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("9ebd806d-08e7-40d6-9dc8-408c590c119d"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("a4ab6df6-66b8-46f7-8198-c94332964006"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("a4e54b1f-3149-4d9b-8d88-e8b4a174a619"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("b3b8f3d5-9efe-497a-9454-d2d16965cfa0"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("c119661c-1d5a-42c1-8819-6b0885af4d4a"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("cdd387fe-0834-494b-9a63-2a622375d36c"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("cf0e7c96-b60b-4c6b-8374-57f827fa17a4"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("dcbbfc78-9191-4ced-97c6-da3c51b1adae"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("e3132a60-2e38-4366-b0ac-59d653e3400f"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("e7136862-7c13-4a57-a05f-e09b9ae98d06"),
                column: "CreatedDate",
                value: new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("eac0f796-b80d-43ff-800e-dfbe0a5dbb60"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("f0aefde0-bc3d-4cfc-b477-00b3ddec847c"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationsId",
                keyValue: new Guid("ff38ccf6-d319-40d1-8869-c7ae8a415f5e"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ReservationId",
                keyValue: new Guid("c4046135-7ef7-4a85-a125-feeea203d4de"),
                columns: new[] { "CheckInDate", "CheckOutDate", "UserId" },
                values: new object[] { new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
