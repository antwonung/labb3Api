using Microsoft.EntityFrameworkCore.Migrations;

namespace labb3Api.Migrations
{
    public partial class updateCollectionAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserInterest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_UserId1",
                table: "UserInterest",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterest_User_UserId1",
                table: "UserInterest",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterest_User_UserId1",
                table: "UserInterest");

            migrationBuilder.DropIndex(
                name: "IX_UserInterest_UserId1",
                table: "UserInterest");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserInterest");
        }
    }
}
