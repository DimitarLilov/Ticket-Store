using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketStore.Data.Migrations
{
    public partial class Fixed_Ad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Events_EveentId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "EveentId",
                table: "Ads",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_EveentId",
                table: "Ads",
                newName: "IX_Ads_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Events_EventId",
                table: "Ads",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Events_EventId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Ads",
                newName: "EveentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_EventId",
                table: "Ads",
                newName: "IX_Ads_EveentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Events_EveentId",
                table: "Ads",
                column: "EveentId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
