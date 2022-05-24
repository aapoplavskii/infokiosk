using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddLinkPcToCc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContentCarousels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Carousels");

            migrationBuilder.AddColumn<int>(
                name: "PageContainerId",
                table: "ContentCarousels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentCarousels_PageContainerId",
                table: "ContentCarousels",
                column: "PageContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCarousels_PageContainers_PageContainerId",
                table: "ContentCarousels",
                column: "PageContainerId",
                principalTable: "PageContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCarousels_PageContainers_PageContainerId",
                table: "ContentCarousels");

            migrationBuilder.DropIndex(
                name: "IX_ContentCarousels_PageContainerId",
                table: "ContentCarousels");

            migrationBuilder.DropColumn(
                name: "PageContainerId",
                table: "ContentCarousels");

            migrationBuilder.AddColumn<int>(
                name: "CarouselId",
                table: "PageContainers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContentCarousels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Carousels",
                type: "text",
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
    }
}
