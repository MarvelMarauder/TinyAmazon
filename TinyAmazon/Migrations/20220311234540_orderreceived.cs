using Microsoft.EntityFrameworkCore.Migrations;

namespace TinyAmazon.Migrations
{
    public partial class orderreceived : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderReceived",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderReceived",
                table: "Orders");
        }
    }
}
