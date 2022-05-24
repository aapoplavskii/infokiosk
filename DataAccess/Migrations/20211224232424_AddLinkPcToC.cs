using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddLinkPcToC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarouselId",
                table: "PageContainers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageContainers_CarouselId",
                table: "PageContainers",
                column: "CarouselId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageContainers_Carousels_CarouselId",
                table: "PageContainers",
                column: "CarouselId",
                principalTable: "Carousels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageContainers_Carousels_CarouselId",
                table: "PageContainers");

            migrationBuilder.DropIndex(
                name: "IX_PageContainers_CarouselId",
                table: "PageContainers");

            migrationBuilder.DropColumn(
                name: "CarouselId",
                table: "PageContainers");
        }
    }
}
