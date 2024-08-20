namespace MVC3.Areas.Access.ViewModels
{
    public class QuestionEvaluateViewModel
    {

        public int QuestionId { get; set; }
        public string Header { get; set; }
        public string AnswerType { get; set; }
        public string[] ChooseItems { get; set; }
        public string Answer { get; set; }
    }
}
