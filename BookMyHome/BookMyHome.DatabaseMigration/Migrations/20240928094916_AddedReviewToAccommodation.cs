using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviewToAccommodation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Review_ReviewId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ReviewId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_AccommodationId",
                table: "Review",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Accommodations_AccommodationId",
                table: "Review",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Accommodations_AccommodationId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_AccommodationId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ReviewId",
                table: "Bookings",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Review_ReviewId",
                table: "Bookings",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "Id");
        }
    }
}
