using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restino.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccommodationId",
                table: "Reservation",
                newName: "AccommodationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccommodationsId",
                table: "Reservation",
                newName: "AccommodationId");
        }
    }
}
