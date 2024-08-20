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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC3.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext _dbcontext;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbcontext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home", new { area = "Identity" });
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailAcive(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json($"This email doesn't exist");
            }
            else
            {
                if (!user.Active)
                {
                    return Json($"This email is not active");
                }
                return Json(true);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
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


            var model = new RegisterViewModel
            {
                Departments = departments,
                Projects = Projects
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.SelectedProjectIds.Any())
                {
                    ModelState.AddModelError("SelectedProjectIds", "you must select project");
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
                    model.Departments = departments;
                    model.Projects = Projects;
                    return View(model);
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    foreach (var projectid in model.SelectedProjectIds)
                    {
                        var departmentUser = new UserDepartmentProject
                        {
                            DepartmentId = model.SelectedDepartmentId,
                            ProjectId = projectid,
                            UserId = user.Id
                        };
                        await _dbcontext.UserDepartmentProject.AddAsync(departmentUser);
                    }

                    await _dbcontext.SaveChangesAsync();

                    return RedirectToAction("index", "Home", new { area = "identity" });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,
                                        model.RememberMe, true);

                if (result.Succeeded)
                {
                    TempData["LoginSuccess"] = true;
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "Home", new { area = "Identity" });
                    }
                }
            }
            ModelState.AddModelError("", "email or password incorrect please try again");

            return View(model);
        }
    }
}
