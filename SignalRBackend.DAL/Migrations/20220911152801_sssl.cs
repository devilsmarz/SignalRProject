using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRBackend.DAL.Migrations
{
    public partial class sssl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_ReplyMessageId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ReplyMessageId",
                table: "Messages",
                newName: "RepliedMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReplyMessageId",
                table: "Messages",
                newName: "IX_Messages_RepliedMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_RepliedMessageId",
                table: "Messages",
                column: "RepliedMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_RepliedMessageId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "RepliedMessageId",
                table: "Messages",
                newName: "ReplyMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RepliedMessageId",
                table: "Messages",
                newName: "IX_Messages_ReplyMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_ReplyMessageId",
                table: "Messages",
                column: "ReplyMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
