using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC3.Areas.Access.ViewModels
{
    public class QuestioninputViewModel
    {
        public string Question_type { get; set; }

        [Required]
        public string Header { get; set; }
        public string Answer_Type { get; set; }
        public bool Active { get; set; } = true;

        public IEnumerable<SelectListItem> AnswerTypeOptions { get; set; }

        public string ChooseItems { get; set; }
    }
}
