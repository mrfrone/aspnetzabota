using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Web.Migrations.Content
{
    public partial class AddNullableToArticlesDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Departments_DepartmentId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Articles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Departments_DepartmentId",
                table: "Articles",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Departments_DepartmentId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Departments_DepartmentId",
                table: "Articles",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
