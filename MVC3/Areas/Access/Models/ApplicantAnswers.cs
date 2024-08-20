namespace MVC3.Areas.Access.Models
{
    public class ApplicantAnswers
    {
        public int ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public int VacancyId { get; set; }

        public Vacancy Vacancy { get; set; }

        public int QuestionId { get; set; }

        public question Question { get; set; }

        public string Answer { get; set; }
    }
}
