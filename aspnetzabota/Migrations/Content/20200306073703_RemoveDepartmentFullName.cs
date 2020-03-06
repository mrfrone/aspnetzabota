using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Web.Migrations.Content
{
    public partial class RemoveDepartmentFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Departments",
                nullable: true);
        }
    }
}
