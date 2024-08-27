using Microsoft.AspNetCore.Identity;

namespace MVC3.Areas.Identity.Models
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }

        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
