using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamyr.Expendity.Server.Service.Migrations
{
    public partial class AddValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "value",
                table: "Expenses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value",
                table: "Expenses");
        }
    }
}
