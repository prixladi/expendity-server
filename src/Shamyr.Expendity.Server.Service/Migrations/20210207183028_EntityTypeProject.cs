using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamyr.Expendity.Server.Service.Migrations
{
    public partial class EntityTypeProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_project_permissions_user_id_project_id",
                table: "ProjectPermissions");

            migrationBuilder.AddColumn<int>(
                name: "project_id",
                table: "ExpenseTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_project_permissions_user_id",
                table: "ProjectPermissions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_project_permissions_user_id_project_id",
                table: "ProjectPermissions",
                columns: new[] { "user_id", "project_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_expense_types_project_id",
                table: "ExpenseTypes",
                column: "project_id");

            migrationBuilder.AddForeignKey(
                name: "fk_expense_types_projects_project_id",
                table: "ExpenseTypes",
                column: "project_id",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_expense_types_projects_project_id",
                table: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "ix_project_permissions_user_id",
                table: "ProjectPermissions");

            migrationBuilder.DropIndex(
                name: "ix_project_permissions_user_id_project_id",
                table: "ProjectPermissions");

            migrationBuilder.DropIndex(
                name: "ix_expense_types_project_id",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "project_id",
                table: "ExpenseTypes");

            migrationBuilder.CreateIndex(
                name: "ix_project_permissions_user_id_project_id",
                table: "ProjectPermissions",
                columns: new[] { "user_id", "project_id" });
        }
    }
}
