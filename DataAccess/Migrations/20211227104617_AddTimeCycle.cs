using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddTimeCycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCarousels_PageContainers_PageContainerId",
                table: "ContentCarousels");

            migrationBuilder.AlterColumn<int>(
                name: "PageContainerId",
                table: "ContentCarousels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeCycle",
                table: "ContentCarousels",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCarousels_PageContainers_PageContainerId",
                table: "ContentCarousels",
                column: "PageContainerId",
                principalTable: "PageContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCarousels_PageContainers_PageContainerId",
                table: "ContentCarousels");

            migrationBuilder.DropColumn(
                name: "TimeCycle",
                table: "ContentCarousels");

            migrationBuilder.AlterColumn<int>(
                name: "PageContainerId",
                table: "ContentCarousels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCarousels_PageContainers_PageContainerId",
                table: "ContentCarousels",
                column: "PageContainerId",
                principalTable: "PageContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
