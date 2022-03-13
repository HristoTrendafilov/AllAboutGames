using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "GamesPlatforms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesPlatforms");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "GamesGenres");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesGenres");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Platforms",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Platforms",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "GamesPlatforms",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesPlatforms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "GamesGenres",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesGenres",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
