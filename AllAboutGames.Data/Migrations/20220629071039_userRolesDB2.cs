using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class userRolesDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRoles_ApplicationUsers_UserID",
                table: "ApplicationUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRoles_Roles_RoleID",
                table: "ApplicationUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserRoles",
                table: "ApplicationUserRoles");

            migrationBuilder.RenameTable(
                name: "ApplicationUserRoles",
                newName: "ApplicationUsersRoles");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRoles_UserID",
                table: "ApplicationUsersRoles",
                newName: "IX_ApplicationUsersRoles_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRoles_RoleID",
                table: "ApplicationUsersRoles",
                newName: "IX_ApplicationUsersRoles_RoleID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 10, 10, 39, 237, DateTimeKind.Local).AddTicks(1486),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 29, 10, 7, 56, 130, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsersRoles",
                table: "ApplicationUsersRoles",
                column: "ApplicationUserRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersRoles_ApplicationUsers_UserID",
                table: "ApplicationUsersRoles",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersRoles_Roles_RoleID",
                table: "ApplicationUsersRoles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersRoles_ApplicationUsers_UserID",
                table: "ApplicationUsersRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersRoles_Roles_RoleID",
                table: "ApplicationUsersRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsersRoles",
                table: "ApplicationUsersRoles");

            migrationBuilder.RenameTable(
                name: "ApplicationUsersRoles",
                newName: "ApplicationUserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersRoles_UserID",
                table: "ApplicationUserRoles",
                newName: "IX_ApplicationUserRoles_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersRoles_RoleID",
                table: "ApplicationUserRoles",
                newName: "IX_ApplicationUserRoles_RoleID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 10, 7, 56, 130, DateTimeKind.Local).AddTicks(4544),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 29, 10, 10, 39, 237, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserRoles",
                table: "ApplicationUserRoles",
                column: "ApplicationUserRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRoles_ApplicationUsers_UserID",
                table: "ApplicationUserRoles",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRoles_Roles_RoleID",
                table: "ApplicationUserRoles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
