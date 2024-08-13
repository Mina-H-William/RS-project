using System.ComponentModel.DataAnnotations;

namespace MVC3.Areas.Access.ViewModels
{
    public class ViewModelQuestion
    {
        public int id { get; set; }

        [Required]
        public string Header { get; set; }

        public string Answer_Type { get; set; }

        public bool Active { get; set; }
    }
}
