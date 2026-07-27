using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserChatRoomToManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ChatRooms_ChatRoomId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChatRoomId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChatRoomId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "ChatRoomUser",
                columns: table => new
                {
                    ChatRoomsChatRoomId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomUser", x => new { x.ChatRoomsChatRoomId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_ChatRoomUser_ChatRooms_ChatRoomsChatRoomId",
                        column: x => x.ChatRoomsChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoomUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomUser_UsersUserId",
                table: "ChatRoomUser",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRoomUser");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatRoomId",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChatRoomId",
                table: "Users",
                column: "ChatRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ChatRooms_ChatRoomId",
                table: "Users",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "ChatRoomId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
