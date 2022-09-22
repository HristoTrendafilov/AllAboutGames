using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 14, 31, 59, 826, DateTimeKind.Local).AddTicks(7749),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 29, 10, 10, 39, 237, DateTimeKind.Local).AddTicks(1486));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 10, 10, 39, 237, DateTimeKind.Local).AddTicks(1486),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 22, 14, 31, 59, 826, DateTimeKind.Local).AddTicks(7749));
        }
    }
}
