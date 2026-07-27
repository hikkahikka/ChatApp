using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatServer.Migrations
{
    /// <inheritdoc />
    public partial class RenameEntitiesId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUser_ChatRooms_ChatRoomsChatRoomId",
                table: "ChatRoomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUser_Users_UsersUserId",
                table: "ChatRoomUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "ChatRoomUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ChatRoomsChatRoomId",
                table: "ChatRoomUser",
                newName: "ChatRoomsId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUser_UsersUserId",
                table: "ChatRoomUser",
                newName: "IX_ChatRoomUser_UsersId");

            migrationBuilder.RenameColumn(
                name: "ChatRoomId",
                table: "ChatRooms",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUser_ChatRooms_ChatRoomsId",
                table: "ChatRoomUser",
                column: "ChatRoomsId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUser_Users_UsersId",
                table: "ChatRoomUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUser_ChatRooms_ChatRoomsId",
                table: "ChatRoomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatRoomUser_Users_UsersId",
                table: "ChatRoomUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Messages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ChatRoomUser",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "ChatRoomsId",
                table: "ChatRoomUser",
                newName: "ChatRoomsChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatRoomUser_UsersId",
                table: "ChatRoomUser",
                newName: "IX_ChatRoomUser_UsersUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChatRooms",
                newName: "ChatRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUser_ChatRooms_ChatRoomsChatRoomId",
                table: "ChatRoomUser",
                column: "ChatRoomsChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "ChatRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatRoomUser_Users_UsersUserId",
                table: "ChatRoomUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
