using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC3.Areas.Identity.Models;
using MVC3.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC3.Areas.Identity.Services
{
    public class PermissionService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PermissionService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> UserHasPermissionAsync(ClaimsPrincipal userprincipal, string permissionName)
        {
            var user = await _userManager.GetUserAsync(userprincipal);

            var roles = await _userManager.GetRolesAsync(user);

            var hasPermission = await _context.RolePermissions
                .Include(rp => rp.Permission)
                .Include(rp => rp.Role)
                .Where(rp => roles.Contains(rp.Role.Name) && rp.Permission.Name == permissionName)
                .AnyAsync();

            return hasPermission;
        }
    }
}
