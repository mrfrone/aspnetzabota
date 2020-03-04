using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Web.Migrations.Content
{
    public partial class LicensesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicensesPhoto_Licenses_LicensesId",
                table: "LicensesPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "LicensesId",
                table: "LicensesPhoto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LicensesPhoto_Licenses_LicensesId",
                table: "LicensesPhoto",
                column: "LicensesId",
                principalTable: "Licenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicensesPhoto_Licenses_LicensesId",
                table: "LicensesPhoto");

            migrationBuilder.AlterColumn<int>(
                name: "LicensesId",
                table: "LicensesPhoto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LicensesPhoto_Licenses_LicensesId",
                table: "LicensesPhoto",
                column: "LicensesId",
                principalTable: "Licenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
