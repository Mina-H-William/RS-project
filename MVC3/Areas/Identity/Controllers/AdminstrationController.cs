using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC3.Areas.Access.Models;
using MVC3.Areas.Identity.Authorization;
using MVC3.Areas.Identity.Models;
using MVC3.Areas.Identity.ViewModels;
using MVC3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC3.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Permission("Admin")]
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _dbcontext;

        public AdminstrationController(RoleManager<ApplicationRole> roleManager,
                                       UserManager<ApplicationUser> userManager,
                                       ApplicationDbContext dbcontext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            model.permissions = await _dbcontext.RolePermissions.Where(rp => rp.RoleId == role.Id)
            .Select(rp => rp.Permission)
            .Distinct()
            .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActive(string userId, bool active)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            user.Active = active; // Update the Active status
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Redirect to ListUsers action after updating the user
                return RedirectToAction("ListUsers");
            }
            else
            {
                // Handle errors, maybe show an error view or message
                return View("Error"); // You can return an error view or handle accordingly
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var users = await userManager.Users
            .Include(u => u.UserDepartmentProject)
                .ThenInclude(udp => udp.Project)
            .Include(u => u.UserDepartmentProject)
                .ThenInclude(udp => udp.Department)
            .ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (TempData["error"] != null)
            {
                ModelState.AddModelError("", TempData["error"] as string);
            }

            var user = await userManager.Users
            .Include(u => u.UserDepartmentProject)
                .ThenInclude(udp => udp.Project)
            .Include(u => u.UserDepartmentProject)
                .ThenInclude(udp => udp.Department)
            .FirstOrDefaultAsync(u => u.Id == id);

            var roles = await userManager.GetRolesAsync(user);

            var departments = await _dbcontext.Department
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName
                })
                .ToListAsync();

            var Projects = await _dbcontext.Project
                .Select(d => new SelectListItem
                {
                    Value = d.ProjectId.ToString(),
                    Text = d.ProjectName
                })
                .ToListAsync();

            var model = new EditUserViewModel()
            {
                user = user,
                Roles = roles,
                SelectedDepartmentId = user.UserDepartmentProject?.FirstOrDefault()?.DepartmentId ?? 0,
                SelectedProjectIds = user.UserDepartmentProject?.Select(d => d.ProjectId)?.ToList() ?? new List<int>(),
                Departments = departments,
                Projects = Projects
            };
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> updateudp(EditUserViewModel model, string id)
        {
            if (!model.SelectedProjectIds.Any())
            {
                TempData["error"] = "you must select at least one project";
                return RedirectToAction("EditUser", new { id = id });
            }

            var upd = await userManager.Users
            .Include(u => u.UserDepartmentProject)
            .FirstOrDefaultAsync(u => u.Id == id);

            if (upd == null)
            {
                return NotFound();
            }

            //get all records of this user in udp
            var existingRecords = upd.UserDepartmentProject.ToList();

            // Remove existing UserDepartmentProject entries for the user
            #region bad
            /*_dbcontext.UserDepartmentProject.RemoveRange(existingRecords);

            //add new rows
            foreach (var projectId in model.SelectedProjectIds)
            {
                upd.UserDepartmentProject.Add(new UserDepartmentProject
                {
                    UsetId = id,
                    DepartmentId = model.SelectedDepartmentId.Value,
                    ProjectId = projectId
                });
            }*/
            #endregion

            // update department id in all records
            foreach (var entry in existingRecords)
            {
                entry.DepartmentId = model.SelectedDepartmentId.Value;
            }

            // get records with projects to delete
            var projectsToRemove = existingRecords
            .Where(udp => !model.SelectedProjectIds.Contains(udp.ProjectId))
            .ToList();

            _dbcontext.UserDepartmentProject.RemoveRange(projectsToRemove);

            // get all projects id in this records
            var existingProjectIds = existingRecords.Select(udp => udp.ProjectId).ToList();

            //get all project that not found in this records
            var newProjects = model.SelectedProjectIds
                .Where(pid => !existingProjectIds.Contains(pid))
                .ToList();

            // add new record to table with new projects
            foreach (var projectId in newProjects)
            {
                var newEntry = new UserDepartmentProject
                {
                    UserId = id,
                    DepartmentId = model.SelectedDepartmentId.Value,
                    ProjectId = projectId
                };
                _dbcontext.UserDepartmentProject.Add(newEntry);
            }

            //save changes
            await _dbcontext.SaveChangesAsync();


            return RedirectToAction("EditUser", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditRolesInUser(string id)
        {
            ViewBag.userId = id;

            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID is required.");
            }

            var model = new List<UserRolesViewModel>();

            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            var roles = roleManager.Roles;

            foreach (var role in roles)
            {
                var userrole = new UserRolesViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userrole.IsSelected = true;
                }
                else
                {
                    userrole.IsSelected = false;
                }

                model.Add(userrole);

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRolesInUser(List<UserRolesViewModel> model, string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"user with Id = {id} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var role = await roleManager.FindByIdAsync(model[i].RoleId);


                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }

                if (i < (model.Count - 1))
                    continue;
                else
                    return RedirectToAction("EditUser", new { id = user.Id });

            }
            ModelState.AddModelError("", "cant update please try again");

            return RedirectToAction("EditRolesInUser", new { id = user.Id });
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole identityRole = new ApplicationRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public async Task<IActionResult> EditPermissionsInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<PermissionsRolesViewModel>();
            var permissions = await _dbcontext.Permissions.ToListAsync();

            foreach (var permission in permissions)
            {
                var PermissionRoleViewModel = new PermissionsRolesViewModel
                {
                    Id = permission.Id,
                    Name = permission.Name
                };

                if (await _dbcontext.RolePermissions.AnyAsync(pr => pr.RoleId == roleId && pr.PermissionId == permission.Id))
                {
                    PermissionRoleViewModel.IsSelected = true;
                }
                else
                {
                    PermissionRoleViewModel.IsSelected = false;
                }

                model.Add(PermissionRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPermissionsInRole(List<PermissionsRolesViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var permission = await _dbcontext.Permissions.FindAsync(model[i].Id);


                if (model[i].IsSelected && !(await _dbcontext.RolePermissions.AnyAsync(pr => pr.RoleId == roleId && pr.PermissionId == permission.Id)))
                {
                    var rolePermission = new RolePermission
                    {
                        RoleId = roleId,
                        PermissionId = permission.Id
                    };

                    _dbcontext.RolePermissions.Add(rolePermission);
                    await _dbcontext.SaveChangesAsync();
                }
                else if (!model[i].IsSelected && await _dbcontext.RolePermissions.AnyAsync(pr => pr.RoleId == roleId && pr.PermissionId == permission.Id))
                {
                    var rolePermission = new RolePermission
                    {
                        RoleId = roleId,
                        PermissionId = permission.Id
                    };

                    _dbcontext.RolePermissions.Remove(rolePermission);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    continue;
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                try
                {
                    //throw new Exception("Test Exception");

                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListRoles");
                }
                catch (SystemException ex)
                {
                    ViewBag.ErrorTitle = $"{role.Name} role is in use";
                    ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users " +
                        $"in this role. If you want to delete this role, please remove the users from " +
                        $"the role and then try to delete";
                    return View("Error");
                }
            }
        }

    }
}
