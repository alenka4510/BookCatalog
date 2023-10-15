using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addUniqueKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserBooks_UserId",
                table: "UserBooks");

            migrationBuilder.DropIndex(
                name: "IX_CategoryBooks_BookId",
                table: "CategoryBooks");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_UserId_BookId_deleted",
                table: "UserBooks",
                columns: new[] { "UserId", "BookId", "deleted" },
                unique: true,
                filter: "deleted = false");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBooks_BookId_CategoryId_deleted",
                table: "CategoryBooks",
                columns: new[] { "BookId", "CategoryId", "deleted" },
                unique: true,
                filter: "deleted = false");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserBooks_UserId_BookId_deleted",
                table: "UserBooks");

            migrationBuilder.DropIndex(
                name: "IX_CategoryBooks_BookId_CategoryId_deleted",
                table: "CategoryBooks");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_UserId",
                table: "UserBooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBooks_BookId",
                table: "CategoryBooks",
                column: "BookId");
        }
    }
}
