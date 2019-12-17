using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Content.Database.Migrations
{
    public partial class AddPostTitleSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "postTitle",
                table: "Sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "postTitle",
                table: "Sliders");
        }
    }
}
