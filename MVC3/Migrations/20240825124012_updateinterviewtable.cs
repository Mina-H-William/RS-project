using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class updateinterviewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "TechnicalInterviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4192ec6d-f822-4c61-8a5f-c160ec716ae4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4a3b35e-812b-450d-b9c3-f8c20451c1ee", "AQAAAAEAACcQAAAAELPNKawTojth5Tzfwxp2ZZKosH/DAI4pgA81S4LO/DjLN8hNnCa+by4k3bqaH1hJ4Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "TechnicalInterviews");

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
    }
}
