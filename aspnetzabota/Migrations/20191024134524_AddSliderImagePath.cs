using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Migrations
{
    public partial class AddSliderImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Sliders");
        }
    }
}
