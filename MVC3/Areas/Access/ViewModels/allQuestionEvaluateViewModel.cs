using System.Collections.Generic;

namespace MVC3.Areas.Access.ViewModels
{
    public class allQuestionEvaluateViewModel
    {
        public int ApplicantId { get; set; }
        public int VacancyId { get; set; }
        public List<QuestionEvaluateViewModel> Questions { get; set; } = new List<QuestionEvaluateViewModel>();
        public int final_ration { get; set; }
    }
}
