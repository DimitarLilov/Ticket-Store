using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketStore.Data.Migrations
{
    public partial class EventsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Events",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Events",
                newName: "Detail");
        }
    }
}
