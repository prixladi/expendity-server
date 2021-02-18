using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamyr.Expendity.Server.Service.Migrations
{
    public partial class InvitePermissionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "invite_permission",
                table: "ProjectInvites",
                newName: "project_permission_type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "project_permission_type",
                table: "ProjectInvites",
                newName: "invite_permission");
        }
    }
}
