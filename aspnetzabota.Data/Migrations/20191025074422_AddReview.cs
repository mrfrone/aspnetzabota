using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Content.Database.Migrations
{
    public partial class AddReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    date = table.Column<DateTime>(nullable: false),
                    author = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    pub = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
