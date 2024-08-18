using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class addDepartmentUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1daac74d-5f76-4358-ad54-930c964ac4e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "147b7a8f-33d8-42d3-bd40-47668c80405a", "AQAAAAEAACcQAAAAEMG3hVP9j+cuO0w0Ddk9PNwO2gmOylLuzKXbnZwtlAHoEnlYjs5uuQ+U/r/ON6vKrA==" });
        }
    }
}
