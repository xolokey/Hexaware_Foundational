using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssertManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAsserts_Asserts_AssertId",
                table: "EmployeeAsserts");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAsserts_AssertId",
                table: "EmployeeAsserts");

            migrationBuilder.RenameColumn(
                name: "AssertId",
                table: "EmployeeAsserts",
                newName: "AssetId");

            migrationBuilder.AddColumn<int>(
                name: "AssertAssetId",
                table: "EmployeeAsserts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAsserts_AssertAssetId",
                table: "EmployeeAsserts",
                column: "AssertAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAsserts_Asserts_AssertAssetId",
                table: "EmployeeAsserts",
                column: "AssertAssetId",
                principalTable: "Asserts",
                principalColumn: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAsserts_Asserts_AssertAssetId",
                table: "EmployeeAsserts");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAsserts_AssertAssetId",
                table: "EmployeeAsserts");

            migrationBuilder.DropColumn(
                name: "AssertAssetId",
                table: "EmployeeAsserts");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "EmployeeAsserts",
                newName: "AssertId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAsserts_AssertId",
                table: "EmployeeAsserts",
                column: "AssertId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAsserts_Asserts_AssertId",
                table: "EmployeeAsserts",
                column: "AssertId",
                principalTable: "Asserts",
                principalColumn: "AssetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
