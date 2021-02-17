using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamyr.Expendity.Server.Service.Migrations
{
  public partial class DecimalPrecision: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<decimal>(
          name: "value",
          table: "Expenses",
          type: "decimal(18,2)",
          nullable: false,
          oldClrType: typeof(double),
          oldType: "float");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<double>(
          name: "value",
          table: "Expenses",
          type: "float",
          nullable: false,
          oldClrType: typeof(decimal),
          oldType: "decimal(18,2)");
    }
  }
}
