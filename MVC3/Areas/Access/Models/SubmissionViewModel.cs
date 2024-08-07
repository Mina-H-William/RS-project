namespace MVC3.Areas.Access.Models
{
    public class SubmissionViewModel
    {
        public int VacancyId { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantLastName { get; set; }
        public int YearsOfExperience { get; set; }
        public string ResumeFilePath { get; set; }
        public int ApplicantId { get; set; }
    }
}
