using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class edituserprojectdepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "UserDepartmentProject",
                columns: table => new
                {
                    UsetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartmentProject", x => new { x.DepartmentId, x.UsetId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserDepartmentProject_AspNetUsers_UsetId",
                        column: x => x.UsetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDepartmentProject_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDepartmentProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9681dbfa-a8f7-474e-a446-efa099481aa3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5603ccdb-e77a-4930-9109-fa69b64d0dbf", "AQAAAAEAACcQAAAAEEnGcSV6fxoBFAm+voPjLnBlA2+rkeSofy5NU4I+OCqICZZpXap8zjN1pZL0m1Puyw==" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Questions" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 9, "1" });

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartmentProject_ProjectId",
                table: "UserDepartmentProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartmentProject_UsetId",
                table: "UserDepartmentProject",
                column: "UsetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDepartmentProject");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 9, "1" });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.CreateTable(
                name: "DepartmentUsers",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    UsetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentUsers", x => new { x.DepartmentId, x.UsetId });
                    table.ForeignKey(
                        name: "FK_DepartmentUsers_AspNetUsers_UsetId",
                        column: x => x.UsetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentUsers_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2db59bd6-5aca-4548-a37a-81866c8aafb0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3d3f469-a5c3-46a1-8cf5-444ae0395e73", "AQAAAAEAACcQAAAAEM1uh0ZWoXR9LadmZufosv6rFbaEsyvbjNMb0L7Fib6PR/EflPliiSTebP5E6ZYmzQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUsers_UsetId",
                table: "DepartmentUsers",
                column: "UsetId");
        }
    }
}
