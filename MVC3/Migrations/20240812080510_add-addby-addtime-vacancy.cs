using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class addaddbyaddtimevacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedTime",
                table: "Vacancy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6a4370ce-144b-4a1d-9497-ec940372e53a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a85918d7-331f-42d5-9ab7-845441c2e875", "AQAAAAEAACcQAAAAEF4toGkx6jTO73cH5Xj+e4LxnR3I53wyx9y2pBnmAR+7dKusAyFuYX9YmZqAO71L9A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedTime",
                table: "Vacancy");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9c8556df-9165-4271-b1bc-ba9e3c408e16");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69844cf1-3b6e-443f-92ce-6d07a8e58db2", "AQAAAAEAACcQAAAAECzkGOa+quMOP01PQ2Adx2doMbTilX5t6+vKN3MzBWcnZACdDmrOEBBHx9bIYUHQBQ==" });
        }
    }
}
