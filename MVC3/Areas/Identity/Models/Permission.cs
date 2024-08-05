using System.Collections.Generic;

namespace MVC3.Areas.Identity.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
