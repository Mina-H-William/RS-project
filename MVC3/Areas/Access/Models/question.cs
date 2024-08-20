using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC3.Areas.Access.Models
{
    public class question
    {
        public int id { get; set; }

        public string Question_type { get; set; }

        public string Header { get; set; }

        public string Answer_Type { get; set; }

        public bool Active { get; set; }

        public string ChooseItems { get; set; }

        public virtual ICollection<ApplicantAnswers> ApplicantAnswers { get; set; }

    }
}
