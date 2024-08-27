using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class lazy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7af7708b-02be-41c3-99e3-4a37c59c7b58");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2cd4f52a-03c6-4e62-a781-bea4a6b45112", "AQAAAAEAACcQAAAAEDExXqARDpBDpwDpOaYhi0xVZTY8bjo/zkwtg/3pD24RtxHVzvvY1jTvhqua+7Chsg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "fc35304b-aeca-41df-a0b7-282a889a4de4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67da9125-1aba-46ea-beef-a4ec987d2fd2", "AQAAAAEAACcQAAAAEFhvuSprD6rcc1iipZm15IBYvnRrRBrxfc3QVYv4WkD2emLoFaXAK5xWKEhjFIZGPA==" });
        }
    }
}
