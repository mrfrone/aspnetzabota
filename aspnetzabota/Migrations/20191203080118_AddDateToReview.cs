using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Migrations
{
    public partial class AddDateToReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "date",
                table: "Reviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Reviews");
        }
    }
}
