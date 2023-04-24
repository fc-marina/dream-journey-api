using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamJourneyAPI.Migrations
{
    public partial class DreamUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DreamModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DreamModel_UserId",
                table: "DreamModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DreamModel_UserModel_UserId",
                table: "DreamModel",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DreamModel_UserModel_UserId",
                table: "DreamModel");

            migrationBuilder.DropIndex(
                name: "IX_DreamModel_UserId",
                table: "DreamModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DreamModel");
        }
    }
}
