using MVC3.Areas.Identity.Models;

namespace MVC3.Areas.Access.Models
{
    public class UserDepartmentProject
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }


    }
}
