using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class addtechnical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechnicalInterviews",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    TechnicalInterviewer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalInterviews", x => new { x.ApplicantId, x.VacancyId });
                    table.ForeignKey(
                        name: "FK_TechnicalInterviews_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalInterviews_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInterviews_VacancyId",
                table: "TechnicalInterviews",
                column: "VacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalInterviews");

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
    }
}
