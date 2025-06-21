using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssertManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateonServiceRequesttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ServiceRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ServiceRequests");
        }
    }
}
