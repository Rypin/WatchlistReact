using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchlistReact.Data.Migrations
{
    /// <inheritdoc />
    public partial class watchlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId1",
                table: "Watchlist");

            migrationBuilder.DropIndex(
                name: "IX_Watchlist_UserId1",
                table: "Watchlist");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Watchlist");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Watchlist",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlist_UserId",
                table: "Watchlist",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId",
                table: "Watchlist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId",
                table: "Watchlist");

            migrationBuilder.DropIndex(
                name: "IX_Watchlist_UserId",
                table: "Watchlist");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Watchlist",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Watchlist",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlist_UserId1",
                table: "Watchlist",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlist_AspNetUsers_UserId1",
                table: "Watchlist",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
