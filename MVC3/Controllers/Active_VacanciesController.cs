using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC3.Data;
using MVC3.Areas.Access.Models;

namespace MVC3.Controllers
{
    public class Active_VacanciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Active_VacanciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Active_Vacancies
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Vacancy.Include(v => v.Title);
            //return View(await applicationDbContext.ToListAsync());
            var activeVacancies = await _context.Vacancy
                .Include(v => v.Title)
                   .Include(v => v.VacancyProjects)
                      .ThenInclude(vp => vp.Project)
                         .Where(v => v.Active)
                               .ToListAsync();

            return View(activeVacancies);
        }

        // GET: Active_Vacancies/Details/5
        // GET: Active_Vacancies/Details/5
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
            ViewBag.VacancyId = vacancy.VacancyId;
            ViewBag.Active = true;
            return View(vacancy);
        }


        // GET: Active_Vacancies/Create
        public IActionResult Create()
        {
            ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleId");
            return View();
        }

        // POST: Active_Vacancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacancyId,VacancyName,TotalVacancyCount,TitleId,Active")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleId", vacancy.TitleId);
            return View(vacancy);
        }

        // GET: Active_Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewData["TitleId"] = new SelectList(_context.Title, "TitleId", "TitleId", vacancy.TitleId);
            ViewBag.VacancyId = vacancy.VacancyId;
            return View(vacancy);
        }

        // POST: Active_Vacancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacancyId,VacancyName,TotalVacancyCount,TitleId,Active")] Vacancy vacancy)
        {
            if (id != vacancy.VacancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancy);
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
            ViewBag.VacancyId = vacancy.VacancyId;
            return View(vacancy);
        }

        // GET: Active_Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .Include(v => v.Title)
                .FirstOrDefaultAsync(m => m.VacancyId == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // POST: Active_Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await _context.Vacancy.FindAsync(id);
            _context.Vacancy.Remove(vacancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancy.Any(e => e.VacancyId == id);
        }
    }
}
