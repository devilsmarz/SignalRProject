using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRBackend.DAL.Migrations
{
    public partial class adsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeletedForMe",
                table: "Messages",
                newName: "isDeletedOnlyForCreator");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Messages",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "isDeletedOnlyForCreator",
                table: "Messages",
                newName: "IsDeletedForMe");
        }
    }
}
