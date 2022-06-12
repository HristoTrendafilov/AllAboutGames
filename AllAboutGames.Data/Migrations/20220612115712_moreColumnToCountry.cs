using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class moreColumnToCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Iso3",
                table: "Countries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NiceName",
                table: "Countries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumCode",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhoneCode",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 12, 14, 57, 12, 62, DateTimeKind.Local).AddTicks(1276),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 12, 14, 38, 31, 126, DateTimeKind.Local).AddTicks(8190));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iso3",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NiceName",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NumCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "Countries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 12, 14, 38, 31, 126, DateTimeKind.Local).AddTicks(8190),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 12, 14, 57, 12, 62, DateTimeKind.Local).AddTicks(1276));
        }
    }
}
