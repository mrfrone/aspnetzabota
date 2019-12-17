using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Content.Database.Migrations
{
    public partial class AddDeprtmentPriceID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentPriceID",
                table: "Departments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentPriceID",
                table: "Departments");
        }
    }
}
