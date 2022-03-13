using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class applicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Xaxas_XaxaID",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Xaxas");

            migrationBuilder.DropIndex(
                name: "IX_Games_XaxaID",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "XaxaID",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "XaxaID",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Xaxas",
                columns: table => new
                {
                    XaxaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    XaxaName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xaxas", x => x.XaxaID);
                });

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
    }
}
