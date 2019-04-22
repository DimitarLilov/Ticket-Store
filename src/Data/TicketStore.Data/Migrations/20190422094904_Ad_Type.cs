using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketStore.Data.Migrations
{
    public partial class Ad_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_TypeId",
                table: "Ads",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdType_TypeId",
                table: "Ads",
                column: "TypeId",
                principalTable: "AdType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdType_TypeId",
                table: "Ads");

            migrationBuilder.DropTable(
                name: "AdType");

            migrationBuilder.DropIndex(
                name: "IX_Ads_TypeId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Ads",
                nullable: false,
                defaultValue: "");
        }
    }
}
