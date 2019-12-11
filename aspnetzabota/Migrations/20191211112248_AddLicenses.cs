using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Migrations
{
    public partial class AddLicenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LicensesPhoto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    path = table.Column<string>(nullable: true),
                    Licensesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensesPhoto", x => x.id);
                    table.ForeignKey(
                        name: "FK_LicensesPhoto_Licenses_Licensesid",
                        column: x => x.Licensesid,
                        principalTable: "Licenses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicensesPhoto_Licensesid",
                table: "LicensesPhoto",
                column: "Licensesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicensesPhoto");

            migrationBuilder.DropTable(
                name: "Licenses");
        }
    }
}
