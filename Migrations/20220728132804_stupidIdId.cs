using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Migrations
{
    public partial class stupidIdId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_Users_OwnerIdId",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityIdId",
                table: "CommunityMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Users_UserIdId",
                table: "CommunityMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_AddresseeIdId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_RequesterIdId",
                table: "Friendships");

            migrationBuilder.RenameColumn(
                name: "RequesterIdId",
                table: "Friendships",
                newName: "RequesterId");

            migrationBuilder.RenameColumn(
                name: "AddresseeIdId",
                table: "Friendships",
                newName: "AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_RequesterIdId",
                table: "Friendships",
                newName: "IX_Friendships_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_AddresseeIdId",
                table: "Friendships",
                newName: "IX_Friendships_AddresseeId");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "CommunityMembers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CommunityIdId",
                table: "CommunityMembers",
                newName: "CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMembers_UserIdId",
                table: "CommunityMembers",
                newName: "IX_CommunityMembers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMembers_CommunityIdId",
                table: "CommunityMembers",
                newName: "IX_CommunityMembers_CommunityId");

            migrationBuilder.RenameColumn(
                name: "OwnerIdId",
                table: "Communities",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_OwnerIdId",
                table: "Communities",
                newName: "IX_Communities_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_Users_OwnerId",
                table: "Communities",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityId",
                table: "CommunityMembers",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Users_UserId",
                table: "CommunityMembers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_AddresseeId",
                table: "Friendships",
                column: "AddresseeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_RequesterId",
                table: "Friendships",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_Users_OwnerId",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityId",
                table: "CommunityMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityMembers_Users_UserId",
                table: "CommunityMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_AddresseeId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_RequesterId",
                table: "Friendships");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "Friendships",
                newName: "RequesterIdId");

            migrationBuilder.RenameColumn(
                name: "AddresseeId",
                table: "Friendships",
                newName: "AddresseeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_RequesterId",
                table: "Friendships",
                newName: "IX_Friendships_RequesterIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_AddresseeId",
                table: "Friendships",
                newName: "IX_Friendships_AddresseeIdId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CommunityMembers",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "CommunityMembers",
                newName: "CommunityIdId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMembers_UserId",
                table: "CommunityMembers",
                newName: "IX_CommunityMembers_UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_CommunityMembers_CommunityId",
                table: "CommunityMembers",
                newName: "IX_CommunityMembers_CommunityIdId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Communities",
                newName: "OwnerIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_OwnerId",
                table: "Communities",
                newName: "IX_Communities_OwnerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_Users_OwnerIdId",
                table: "Communities",
                column: "OwnerIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Communities_CommunityIdId",
                table: "CommunityMembers",
                column: "CommunityIdId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityMembers_Users_UserIdId",
                table: "CommunityMembers",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_AddresseeIdId",
                table: "Friendships",
                column: "AddresseeIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_RequesterIdId",
                table: "Friendships",
                column: "RequesterIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
