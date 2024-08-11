using System.ComponentModel.DataAnnotations;

namespace MVC3.Areas.Access.Models
{
    public class Nationality
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nationality name is required")]
        public string Name { get; set; }
    }
}
