using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class userEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 8, 9, 27, 52, 639, DateTimeKind.Local).AddTicks(6894),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 4, 12, 39, 59, 267, DateTimeKind.Local).AddTicks(338));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 4, 12, 39, 59, 267, DateTimeKind.Local).AddTicks(338),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 8, 9, 27, 52, 639, DateTimeKind.Local).AddTicks(6894));
        }
    }
}
