using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamyr.Expendity.Server.Service.Migrations
{
    public partial class ProjectInvite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectInvites",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    invite_permission = table.Column<int>(type: "int", nullable: false),
                    is_multi_use = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_project_invites", x => x.id);
                    table.ForeignKey(
                        name: "fk_project_invites_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_project_invites_project_id",
                table: "ProjectInvites",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_project_invites_token",
                table: "ProjectInvites",
                column: "token",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectInvites");
        }
    }
}
