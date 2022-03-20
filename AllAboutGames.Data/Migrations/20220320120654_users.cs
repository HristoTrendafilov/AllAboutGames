using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllAboutGames.Data.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Cities_CityID",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUser_UserID",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_Role_RoleID",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_ApplicationUser_UserID",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumComments_ApplicationUser_UserID",
                table: "ForumComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumLikes_ApplicationUser_UserID",
                table: "ForumLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ApplicationUser_UserID",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ApplicationUser_UserID",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUser_UserID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "ApplicationUsers");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_CityID",
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
                oldDefaultValue: new DateTime(2022, 3, 16, 17, 19, 34, 791, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "UserID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Cities_CityID",
                table: "ApplicationUsers",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_ApplicationUsers_UserID",
                table: "FeedBack",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumComments_ApplicationUsers_UserID",
                table: "ForumComments",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumLikes_ApplicationUsers_UserID",
                table: "ForumLikes",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ApplicationUsers_UserID",
                table: "ForumPosts",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ApplicationUsers_UserID",
                table: "Ratings",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUsers_UserID",
                table: "Reviews",
                column: "UserID",
                principalTable: "ApplicationUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUsers_UserID",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_Roles_RoleID",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Cities_CityID",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_ApplicationUsers_UserID",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumComments_ApplicationUsers_UserID",
                table: "ForumComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumLikes_ApplicationUsers_UserID",
                table: "ForumLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ApplicationUsers_UserID",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ApplicationUsers_UserID",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ApplicationUsers_UserID",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_CityID",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_CityID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUser",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 16, 17, 19, 34, 791, DateTimeKind.Utc).AddTicks(5190),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 3, 20, 12, 6, 54, 876, DateTimeKind.Utc).AddTicks(2970));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Cities_CityID",
                table: "ApplicationUser",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUser_UserID",
                table: "ApplicationUserRole",
                column: "UserID",
                principalTable: "ApplicationUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_Role_RoleID",
                table: "ApplicationUserRole",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_ApplicationUser_UserID",
                table: "FeedBack",
                column: "UserID",
                principalTable: "ApplicationUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumComments_ApplicationUser_UserID",
                table: "ForumComments",
                column: "UserID",
                principalTable: "ApplicationUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumLikes_ApplicationUser_UserID",
                table: "ForumLikes",
                column: "UserID",
                principalTable: "ApplicationUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ApplicationUser_UserID",
                table: "ForumPosts",
                column: "UserID",
                principalTable: "ApplicationUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ApplicationUser_UserID",
                table: "Ratings",
                column: "UserID",
                principalTable: "ApplicationUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ApplicationUser_UserID",
                table: "Reviews",
                column: "UserID",
                principalTable: "ApplicationUser",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
