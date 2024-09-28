using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.DatabaseMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviewToAccommodation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Accommodations_AccommodationId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_AccommodationId",
                table: "Reviews",
                newName: "IX_Reviews_AccommodationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Accommodations_AccommodationId",
                table: "Reviews",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Accommodations_AccommodationId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_AccommodationId",
                table: "Review",
                newName: "IX_Review_AccommodationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Accommodations_AccommodationId",
                table: "Review",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");
        }
    }
}
