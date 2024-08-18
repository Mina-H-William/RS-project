using MVC3.Areas.Identity.Models;

namespace MVC3.Areas.Access.Models
{
    public class DepartmentUser
    {
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public string UsetId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
