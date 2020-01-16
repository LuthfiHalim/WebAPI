using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class updateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
