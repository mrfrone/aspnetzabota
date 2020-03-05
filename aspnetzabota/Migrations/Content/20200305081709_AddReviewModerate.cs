using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Web.Migrations.Content
{
    public partial class AddReviewModerate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsModerated",
                table: "Reviews",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsModerated",
                table: "Reviews");
        }
    }
}
