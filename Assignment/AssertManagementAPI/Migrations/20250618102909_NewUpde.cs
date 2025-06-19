using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssertManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewUpde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRole_UserRoleRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_UserRoleRoleId",
                table: "Users",
                column: "UserRoleRoleId",
                principalTable: "Role",
                principalColumn: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_UserRoleRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRole_UserRoleRoleId",
                table: "Users",
                column: "UserRoleRoleId",
                principalTable: "UserRole",
                principalColumn: "RoleId");
        }
    }
}
