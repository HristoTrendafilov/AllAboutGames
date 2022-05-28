using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class removedCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Cities_CityID",
                table: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "ApplicationUsers",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_CityID",
                table: "ApplicationUsers",
                newName: "IX_ApplicationUsers_CountryID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 28, 15, 13, 43, 974, DateTimeKind.Utc).AddTicks(1924),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 3, 20, 12, 6, 54, 876, DateTimeKind.Utc).AddTicks(2970));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Countries_CountryID",
                table: "ApplicationUsers",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Countries_CountryID",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "ApplicationUsers",
                newName: "CityID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_CountryID",
                table: "ApplicationUsers",
                newName: "IX_ApplicationUsers_CityID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 20, 12, 6, 54, 876, DateTimeKind.Utc).AddTicks(2970),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 5, 28, 15, 13, 43, 974, DateTimeKind.Utc).AddTicks(1924));

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountryID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Cities_CityID",
                table: "ApplicationUsers",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
