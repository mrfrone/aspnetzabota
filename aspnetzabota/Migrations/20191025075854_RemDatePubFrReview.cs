using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Migrations
{
    public partial class RemDatePubFrReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "pub",
                table: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<short>(
                name: "pub",
                table: "Reviews",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
