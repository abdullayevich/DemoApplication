using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.DataAccess.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ProductAudits");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "ProductAudits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductAudits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAudits_AdminId",
                table: "ProductAudits",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAudits_Admins_AdminId",
                table: "ProductAudits",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAudits_Admins_AdminId",
                table: "ProductAudits");

            migrationBuilder.DropIndex(
                name: "IX_ProductAudits_AdminId",
                table: "ProductAudits");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "ProductAudits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductAudits");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ProductAudits",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
