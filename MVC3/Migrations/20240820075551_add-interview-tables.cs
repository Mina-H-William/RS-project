using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC3.Migrations
{
    public partial class addinterviewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantAnswers",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantAnswers", x => new { x.ApplicantId, x.VacancyId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ApplicantAnswers_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantAnswers_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantAnswers_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantStatus",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    HR = table.Column<bool>(type: "bit", nullable: false),
                    Technical = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantStatus", x => new { x.ApplicantId, x.VacancyId });
                    table.ForeignKey(
                        name: "FK_ApplicantStatus_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantStatus_Vacancy_VacancyId",
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
                value: "65497314-477e-43a2-9ffc-b3e824616000");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc52c8b8-01e6-411b-9e6f-8397bf7b333c", "AQAAAAEAACcQAAAAELORVmRiNWA1NocUN2ePsEatDDbRlrGCm/F4yAa9mDTfR208aLMA6/lgDCjrNvxqEg==" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAnswers_QuestionId",
                table: "ApplicantAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAnswers_VacancyId",
                table: "ApplicantAnswers",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantStatus_VacancyId",
                table: "ApplicantStatus",
                column: "VacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantAnswers");

            migrationBuilder.DropTable(
                name: "ApplicantStatus");

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
        }
    }
}
