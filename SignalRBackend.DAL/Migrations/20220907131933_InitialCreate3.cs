using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRBackend.DAL.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "eff" });

            migrationBuilder.InsertData(
                table: "ChatUser",
                columns: new[] { "ChatsId", "UsersId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ChatUser",
                columns: new[] { "ChatsId", "UsersId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "ChatUser",
                columns: new[] { "ChatsId", "UsersId" },
                values: new object[] { 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
