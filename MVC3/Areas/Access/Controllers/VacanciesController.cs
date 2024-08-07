using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC3.Data;
using MVC3.Areas.Access.Models;

namespace MVC3.Areas.Access.Controllers
{
    [Area("Access")]
    public class VacanciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacanciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vacancies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vacancy
                .Include(v => v.Title)
                .Include(v => v.VacancyProjects)
                    .ThenInclude(vp => vp.Project);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.Title)
                .Include(v => v.VacancyProjects)
                .ThenInclude(vp => vp.Project)
                .FirstOrDefaultAsync(m => m.VacancyId == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // GET: Vacancies/Create
        public IActionResult Create()
        {
            ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleName");
            ViewData["Projects"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: Vacancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacancyId,VacancyName,TotalVacancyCount,TitleId,Active,SelectedProjectIds")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                if (vacancy.SelectedProjectIds != null)
                {
                    vacancy.VacancyProjects = new List<VacancyProject>();
                    foreach (var projectId in vacancy.SelectedProjectIds)
                    {
                        vacancy.VacancyProjects.Add(new VacancyProject { ProjectId = projectId });
                    }
                }
                _context.Add(vacancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleName", vacancy.TitleId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName", vacancy.SelectedProjectIds);
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vacancy = await _context.Vacancy
        //        .Include(v => v.VacancyProjects)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(v => v.VacancyId == id);
        //    if (vacancy == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleId", vacancy.TitleId);
        //    ViewData["ProjectId"] = new MultiSelectList(_context.Project, "ProjectId", "ProjectName", vacancy.VacancyProjects.Select(vp => vp.ProjectId));
        //    return View(vacancy);
        //}

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.VacancyProjects)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VacancyId == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            vacancy.SelectedProjectIds = vacancy.VacancyProjects.Select(vp => vp.ProjectId).ToArray();

            ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleName", vacancy.TitleId);
            ViewData["ProjectId"] = new MultiSelectList(_context.Project, "ProjectId", "ProjectName", vacancy.SelectedProjectIds);

            return View(vacancy);
        }


        // POST: Vacancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("VacancyId,VacancyName,TotalVacancyCount,TitleId,Active")] Vacancy vacancy, int[] selectedProjects)
        //{
        //    if (id != vacancy.VacancyId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(vacancy);

        //            // Update projects
        //            var existingProjects = _context.VacancyProject.Where(vp => vp.VacancyId == id);
        //            _context.VacancyProject.RemoveRange(existingProjects);
        //            if (selectedProjects != null)
        //            {
        //                vacancy.VacancyProjects = new List<VacancyProject>();
        //                foreach (var projectId in selectedProjects)
        //                {
        //                    vacancy.VacancyProjects.Add(new VacancyProject { VacancyId = id, ProjectId = projectId });
        //                }
        //            }

        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!VacancyExists(vacancy.VacancyId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleId", vacancy.TitleId);
        //    ViewData["ProjectId"] = new MultiSelectList(_context.Project, "ProjectId", "ProjectName", selectedProjects);
        //    return View(vacancy);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacancyId,VacancyName,TotalVacancyCount,TitleId,Active,SelectedProjectIds")] Vacancy vacancy)
        {
            if (id != vacancy.VacancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update vacancy details
                    _context.Update(vacancy);

                    // Update projects
                    var existingProjects = _context.VacancyProject.Where(vp => vp.VacancyId == id);
                    _context.VacancyProject.RemoveRange(existingProjects);

                    if (vacancy.SelectedProjectIds != null)
                    {
                        foreach (var projectId in vacancy.SelectedProjectIds)
                        {
                            _context.VacancyProject.Add(new VacancyProject { VacancyId = id, ProjectId = projectId });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.VacancyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleId", vacancy.TitleId);
            ViewData["ProjectId"] = new MultiSelectList(_context.Project, "ProjectId", "ProjectName", vacancy.SelectedProjectIds);

            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.Title)
                .Include(v => v.VacancyProjects)
                    .ThenInclude(vp => vp.Project)
                .FirstOrDefaultAsync(m => m.VacancyId == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await _context.Vacancy
                .Include(v => v.VacancyProjects)
                    .ThenInclude(vp => vp.Project)
                    .FirstOrDefaultAsync(v => v.VacancyId == id);
            _context.Vacancy.Remove(vacancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Vacancies/ActiveVacancies
        public async Task<IActionResult> ActiveVacancies()
        {
            var activeVacancies = await _context.Vacancy
                .Include(v => v.Title)
                .Include(v => v.VacancyProjects)
                    .ThenInclude(vp => vp.Project)
                .Where(v => v.Active)
                .ToListAsync();

            return View(activeVacancies);
        }


        private bool VacancyExists(int id)
        {
            return _context.Vacancy.Any(e => e.VacancyId == id);
        }
    }
}
