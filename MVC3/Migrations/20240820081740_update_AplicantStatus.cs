using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class update_AplicantStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HR_Rating",
                table: "ApplicantStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Technical_rating",
                table: "ApplicantStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HR_Rating",
                table: "ApplicantStatus");

            migrationBuilder.DropColumn(
                name: "Technical_rating",
                table: "ApplicantStatus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "65497314-477e-43a2-9ffc-b3e824616000");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc52c8b8-01e6-411b-9e6f-8397bf7b333c", "AQAAAAEAACcQAAAAELORVmRiNWA1NocUN2ePsEatDDbRlrGCm/F4yAa9mDTfR208aLMA6/lgDCjrNvxqEg==" });
        }
    }
}
