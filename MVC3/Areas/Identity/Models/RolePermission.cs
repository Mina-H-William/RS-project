using Microsoft.AspNetCore.Identity;

namespace MVC3.Areas.Identity.Models
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
