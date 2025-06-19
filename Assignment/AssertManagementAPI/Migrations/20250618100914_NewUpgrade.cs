using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssertManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategories", x => x.CategoryId);
                });

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

            migrationBuilder.CreateTable(
                name: "Asserts",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManufacturingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsAvilable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asserts", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Asserts_AssetCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditRequests",
                columns: table => new
                {
                    AuditRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuditStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssertAssetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRequests", x => x.AuditRequestId);
                    table.ForeignKey(
                        name: "FK_AuditRequests_Asserts_AssertAssetId",
                        column: x => x.AssertAssetId,
                        principalTable: "Asserts",
                        principalColumn: "AssetId");
                    table.ForeignKey(
                        name: "FK_AuditRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAsserts",
                columns: table => new
                {
                    AllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AssertId = table.Column<int>(type: "int", nullable: false),
                    AllocationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAsserts", x => x.AllocationId);
                    table.ForeignKey(
                        name: "FK_EmployeeAsserts_Asserts_AssertId",
                        column: x => x.AssertId,
                        principalTable: "Asserts",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAsserts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssertAssetId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Asserts_AssertAssetId",
                        column: x => x.AssertAssetId,
                        principalTable: "Asserts",
                        principalColumn: "AssetId");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssertAuditLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditRequestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifiedBy = table.Column<int>(type: "int", nullable: true),
                    VerifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifiedByNavigationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssertAuditLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_AssertAuditLogs_AuditRequests_AuditRequestId",
                        column: x => x.AuditRequestId,
                        principalTable: "AuditRequests",
                        principalColumn: "AuditRequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssertAuditLogs_Users_VerifiedByNavigationUserId",
                        column: x => x.VerifiedByNavigationUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleRoleId",
                table: "Users",
                column: "UserRoleRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AssertAuditLogs_AuditRequestId",
                table: "AssertAuditLogs",
                column: "AuditRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AssertAuditLogs_VerifiedByNavigationUserId",
                table: "AssertAuditLogs",
                column: "VerifiedByNavigationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Asserts_CategoryId",
                table: "Asserts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditRequests_AssertAssetId",
                table: "AuditRequests",
                column: "AssertAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditRequests_UserId",
                table: "AuditRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAsserts_AssertId",
                table: "EmployeeAsserts",
                column: "AssertId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAsserts_UserId",
                table: "EmployeeAsserts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_AssertAssetId",
                table: "ServiceRequests",
                column: "AssertAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_UserId",
                table: "ServiceRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRole_UserRoleRoleId",
                table: "Users",
                column: "UserRoleRoleId",
                principalTable: "UserRole",
                principalColumn: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRole_UserRoleRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AssertAuditLogs");

            migrationBuilder.DropTable(
                name: "EmployeeAsserts");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "AuditRequests");

            migrationBuilder.DropTable(
                name: "Asserts");

            migrationBuilder.DropTable(
                name: "AssetCategories");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRoleRoleId",
                table: "Users");
        }
    }
}
