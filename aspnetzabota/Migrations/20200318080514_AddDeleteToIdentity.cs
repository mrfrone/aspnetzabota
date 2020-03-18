using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnetzabota.Web.Migrations
{
    public partial class AddDeleteToIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Deleted",
                table: "Identities",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Identities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Identities",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Identities");
        }
    }
}
