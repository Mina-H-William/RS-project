using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class editudptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UsetId",
                table: "UserDepartmentProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDepartmentProject",
                table: "UserDepartmentProject");

            migrationBuilder.AlterColumn<string>(
                name: "UsetId",
                table: "UserDepartmentProject",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserDepartmentProject",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDepartmentProject",
                table: "UserDepartmentProject",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartmentProject_DepartmentId",
                table: "UserDepartmentProject",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UsetId",
                table: "UserDepartmentProject",
                column: "UsetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UsetId",
                table: "UserDepartmentProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDepartmentProject",
                table: "UserDepartmentProject");

            migrationBuilder.DropIndex(
                name: "IX_UserDepartmentProject_DepartmentId",
                table: "UserDepartmentProject");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserDepartmentProject");

            migrationBuilder.AlterColumn<string>(
                name: "UsetId",
                table: "UserDepartmentProject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDepartmentProject",
                table: "UserDepartmentProject",
                columns: new[] { "DepartmentId", "UsetId", "ProjectId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserDepartmentProject_AspNetUsers_UsetId",
                table: "UserDepartmentProject",
                column: "UsetId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
