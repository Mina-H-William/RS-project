using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class editudptable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UsetId",
                table: "UserDepartmentProject");

            migrationBuilder.RenameColumn(
                name: "UsetId",
                table: "UserDepartmentProject",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDepartmentProject_UsetId",
                table: "UserDepartmentProject",
                newName: "IX_UserDepartmentProject_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ca772001-570a-4b59-bc5e-f69e0ec968db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c27e3580-9d1a-461e-b781-26d3b8ed4dc3", "AQAAAAEAACcQAAAAEFIAnCmeK5sRfL5ef3AempgZwBHX8enszyl7j7z83m7Z9zXD4lkFNqjMcKOE2vVNig==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UserId",
                table: "UserDepartmentProject",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UserId",
                table: "UserDepartmentProject");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserDepartmentProject",
                newName: "UsetId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDepartmentProject_UserId",
                table: "UserDepartmentProject",
                newName: "IX_UserDepartmentProject_UsetId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b02c1dbf-4ea4-4bd0-9ea3-43801942f89f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9fcc4cb4-b667-4961-90d8-1ebb1bc3f4ef", "AQAAAAEAACcQAAAAEIZrKKyky6x+anR5SgZ7pdqq30IyQcwmpnXgNav2SDIfaHrk287+f8p72p6/VUeJQQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UsetId",
                table: "UserDepartmentProject",
                column: "UsetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
