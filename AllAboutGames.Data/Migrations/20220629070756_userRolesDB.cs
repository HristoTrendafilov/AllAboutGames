using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class userRolesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUsers_UserID",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_Roles_RoleID",
                table: "ApplicationUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserRole",
                table: "ApplicationUserRole");

            migrationBuilder.RenameTable(
                name: "ApplicationUserRole",
                newName: "ApplicationUserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_UserID",
                table: "ApplicationUserRoles",
                newName: "IX_ApplicationUserRoles_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRole_RoleID",
                table: "ApplicationUserRoles",
                newName: "IX_ApplicationUserRoles_RoleID");

            migrationBuilder.AlterColumn<string>(
                name: "Iso",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 10, 7, 56, 130, DateTimeKind.Local).AddTicks(4544),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 12, 15, 1, 58, 178, DateTimeKind.Local).AddTicks(9899));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "ApplicationUserRole");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRoles_UserID",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserRoles_RoleID",
                table: "ApplicationUserRole",
                newName: "IX_ApplicationUserRole_RoleID");

            migrationBuilder.AlterColumn<string>(
                name: "Iso",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 12, 15, 1, 58, 178, DateTimeKind.Local).AddTicks(9899),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 6, 29, 10, 7, 56, 130, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserRole",
                table: "ApplicationUserRole",
                column: "ApplicationUserRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUsers_UserID",
                table: "ApplicationUserRole",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_Roles_RoleID",
                table: "ApplicationUserRole",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
