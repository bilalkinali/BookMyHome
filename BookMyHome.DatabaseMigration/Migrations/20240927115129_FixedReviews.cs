using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class FixedReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Bookings_BookingId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_BookingId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Review");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "BookingId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookingId",
                table: "Review",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Bookings_BookingId",
                table: "Review",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
