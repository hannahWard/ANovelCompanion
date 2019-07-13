using Microsoft.EntityFrameworkCore.Migrations;

namespace ANovelCompanion.Data.Migrations
{
    public partial class AddAverageRatingToBookListTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RatingsAndReviews_BookId",
                table: "RatingsAndReviews",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingsAndReviews_Books_BookId",
                table: "RatingsAndReviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingsAndReviews_Books_BookId",
                table: "RatingsAndReviews");

            migrationBuilder.DropIndex(
                name: "IX_RatingsAndReviews_BookId",
                table: "RatingsAndReviews");
        }
    }
}
