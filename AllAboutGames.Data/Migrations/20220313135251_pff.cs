using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class pff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "XaxaID",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_XaxaID",
                table: "Games",
                column: "XaxaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Xaxas_XaxaID",
                table: "Games",
                column: "XaxaID",
                principalTable: "Xaxas",
                principalColumn: "XaxaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Xaxas_XaxaID",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_XaxaID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "XaxaID",
                table: "Games");
        }
    }
}
