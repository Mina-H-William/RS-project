namespace MVC3.Areas.Access.Models
{
    public class ApplicantAnswers
    {
        public int ApplicantId { get; set; }

        public virtual Applicant Applicant { get; set; }

        public int VacancyId { get; set; }

        public virtual Vacancy Vacancy { get; set; }

        public int QuestionId { get; set; }

        public virtual question Question { get; set; }

        public string Answer { get; set; }
    }
}
