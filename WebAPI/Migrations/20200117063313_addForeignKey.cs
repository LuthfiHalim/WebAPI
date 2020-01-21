using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class addForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_Postid",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Postid",
                table: "Comments",
                newName: "postid");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Postid",
                table: "Comments",
                newName: "IX_Comments_postid");

            migrationBuilder.AlterColumn<int>(
                name: "postid",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postid",
                table: "Comments",
                column: "postid",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postid",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "postid",
                table: "Comments",
                newName: "Postid");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_postid",
                table: "Comments",
                newName: "IX_Comments_Postid");

            migrationBuilder.AlterColumn<int>(
                name: "Postid",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_Postid",
                table: "Comments",
                column: "Postid",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
