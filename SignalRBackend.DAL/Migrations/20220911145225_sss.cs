using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRBackend.DAL.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReplyMessageId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReplyMessageId",
                table: "Messages",
                column: "ReplyMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_ReplyMessageId",
                table: "Messages",
                column: "ReplyMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_ReplyMessageId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReplyMessageId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReplyMessageId",
                table: "Messages");
        }
    }
}
