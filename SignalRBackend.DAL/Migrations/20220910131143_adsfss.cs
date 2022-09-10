using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRBackend.DAL.Migrations
{
    public partial class adsfss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeletedOnlyForCreator",
                table: "Messages",
                newName: "IsDeletedOnlyForCreator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeletedOnlyForCreator",
                table: "Messages",
                newName: "isDeletedOnlyForCreator");
        }
    }
}
