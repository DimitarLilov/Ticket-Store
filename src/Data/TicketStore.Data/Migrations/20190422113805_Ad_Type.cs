using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketStore.Data.Migrations
{
    public partial class Ad_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdType_TypeId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdType",
                table: "AdType");

            migrationBuilder.RenameTable(
                name: "AdType",
                newName: "AdTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdTypes",
                table: "AdTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdTypes_TypeId",
                table: "Ads",
                column: "TypeId",
                principalTable: "AdTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdTypes_TypeId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdTypes",
                table: "AdTypes");

            migrationBuilder.RenameTable(
                name: "AdTypes",
                newName: "AdType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdType",
                table: "AdType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdType_TypeId",
                table: "Ads",
                column: "TypeId",
                principalTable: "AdType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
