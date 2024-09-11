using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class FixHostAndAccommodations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Accommodations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AccommodationId",
                table: "Bookings",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Accommodations_AccommodationId",
                table: "Bookings",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Accommodations_AccommodationId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AccommodationId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Accommodations");
        }
    }
}
