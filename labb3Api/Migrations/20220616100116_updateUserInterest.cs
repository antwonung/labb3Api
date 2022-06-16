using Microsoft.EntityFrameworkCore.Migrations;

namespace labb3Api.Migrations
{
    public partial class updateUserInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInterest_InterestId",
                table: "UserInterest");

            migrationBuilder.AddPrimaryKey(
                name: "Primary_Key_UserInterest",
                table: "UserInterest",
                columns: new[] { "InterestId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Primary_Key_UserInterest",
                table: "UserInterest");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_InterestId",
                table: "UserInterest",
                column: "InterestId");
        }
    }
}
