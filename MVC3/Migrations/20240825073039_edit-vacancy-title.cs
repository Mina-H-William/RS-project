using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class editvacancytitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e7e6468c-1cf4-42e7-ba77-cea8180b96e3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "06a634b1-1977-446f-bcdb-4475d5d834fb", "AQAAAAEAACcQAAAAECvo22Q6INnjYJIbUX306x0XIL50NGlaJ5UX72YkvsdD5H4B2ZbdLKucH8fVI8yqlA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cf42d787-be42-4f0c-b132-c9948f016d99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fd2754c-f658-416f-9320-dd5d1323d6cf", "AQAAAAEAACcQAAAAECt5uckx4QYv4H0tJVrIQ7hhr7CzVuvaJT030rLH6YBfa/6S3t3R1/35K1j894JYZg==" });
        }
    }
}
