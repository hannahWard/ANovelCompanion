using Microsoft.EntityFrameworkCore.Migrations;

namespace ANovelCompanion.Data.Migrations
{
    public partial class AddBookEditWithCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryBook_Books_BookId",
                table: "CategoryBook");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryBook_Categories_CategoryId",
                table: "CategoryBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryBook",
                table: "CategoryBook");

            migrationBuilder.RenameTable(
                name: "CategoryBook",
                newName: "CategoryBooks");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryBook_CategoryId",
                table: "CategoryBooks",
                newName: "IX_CategoryBooks_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryBook_BookId",
                table: "CategoryBooks",
                newName: "IX_CategoryBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryBooks",
                table: "CategoryBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryBooks_Books_BookId",
                table: "CategoryBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryBooks_Categories_CategoryId",
                table: "CategoryBooks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryBooks_Books_BookId",
                table: "CategoryBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryBooks_Categories_CategoryId",
                table: "CategoryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryBooks",
                table: "CategoryBooks");

            migrationBuilder.RenameTable(
                name: "CategoryBooks",
                newName: "CategoryBook");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryBooks_CategoryId",
                table: "CategoryBook",
                newName: "IX_CategoryBook_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryBooks_BookId",
                table: "CategoryBook",
                newName: "IX_CategoryBook_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryBook",
                table: "CategoryBook",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryBook_Books_BookId",
                table: "CategoryBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryBook_Categories_CategoryId",
                table: "CategoryBook",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
