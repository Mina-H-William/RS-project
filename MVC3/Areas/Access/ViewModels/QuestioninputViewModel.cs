using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MVC3.Areas.Access.ViewModels
{
    public class QuestioninputViewModel
    {
        public string Question_type { get; set; }
        public string Header { get; set; }
        public string Answer_Type { get; set; }
        public bool Active { get; set; }

        public IEnumerable<SelectListItem> AnswerTypeOptions { get; set; }
    }
}
