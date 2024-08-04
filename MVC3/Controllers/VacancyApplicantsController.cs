using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC3.Data;
using MVC3.Models;

namespace MVC3.Controllers
{
    //[Authorize]
    public class VacancyApplicantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacancyApplicantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VacancyApplicants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VacancyApplicant
                .Include(v => v.Applicant)
                .Include(v => v.Location)
                .Include(v => v.Vacancy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VacancyApplicants/Details/5/10
        public async Task<IActionResult> Details(int vacancyId, int applicantId)
        {
            var vacancyApplicant = await _context.VacancyApplicant
                .Include(v => v.Applicant)
                .Include(v => v.Location)
                .Include(v => v.Vacancy)
                .FirstOrDefaultAsync(m => m.VacancyId == vacancyId && m.ApplicantId == applicantId);

            if (vacancyApplicant == null)
            {
                return NotFound();
            }

            return View(vacancyApplicant);
        }

        // GET: VacancyApplicants/Create
        public IActionResult Create(int applicantId, int vacancyId)
        {
            ViewData["ApplicantId"] = applicantId;
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
            ViewData["VacancyId"] = vacancyId;
            return View();
        }

        // POST: VacancyApplicants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantId,VacancyId,ExpectedSalary,HearAboutVacancy,WorkAtCompany,RelativeAtCompany,LocationId")] VacancyApplicant vacancyApplicant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancyApplicant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ApplicantId"] = new SelectList(_context.Applicant, "ApplicantId", "ApplicantId", vacancyApplicant.ApplicantId);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", vacancyApplicant.LocationId);
            ViewData["VacancyId"] = new SelectList(_context.Vacancy, "VacancyId", "VacancyId", vacancyApplicant.VacancyId);
            return View(vacancyApplicant);
        }

        // GET: VacancyApplicants/Edit/5/10
        public async Task<IActionResult> Edit(int vacancyId, int applicantId)
        {
            var vacancyApplicant = await _context.VacancyApplicant
                .Include(v => v.Applicant)
                .Include(v => v.Location)
                .Include(v => v.Vacancy)
                .FirstOrDefaultAsync(m => m.VacancyId == vacancyId && m.ApplicantId == applicantId);

            if (vacancyApplicant == null)
            {
                return NotFound();
            }

            ViewData["ApplicantId"] = new SelectList(_context.Applicant, "ApplicantId", "ApplicantId", vacancyApplicant.ApplicantId);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", vacancyApplicant.LocationId);
            ViewData["VacancyId"] = new SelectList(_context.Vacancy, "VacancyId", "VacancyId", vacancyApplicant.VacancyId);
            return View(vacancyApplicant);
        }

        // POST: VacancyApplicants/Edit/5/10
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int vacancyId, int applicantId, [Bind("ApplicantId,VacancyId,ExpectedSalary,HearAboutVacancy,WorkAtCompany,RelativeAtCompany,LocationId")] VacancyApplicant vacancyApplicant)
        {
            if (vacancyId != vacancyApplicant.VacancyId || applicantId != vacancyApplicant.ApplicantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyApplicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyApplicantExists(vacancyApplicant.VacancyId, vacancyApplicant.ApplicantId))
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

            ViewData["ApplicantId"] = new SelectList(_context.Applicant, "ApplicantId", "ApplicantId", vacancyApplicant.ApplicantId);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", vacancyApplicant.LocationId);
            ViewData["VacancyId"] = new SelectList(_context.Vacancy, "VacancyId", "VacancyId", vacancyApplicant.VacancyId);
            return View(vacancyApplicant);
        }

        // GET: VacancyApplicants/Delete/5/10
        public async Task<IActionResult> Delete(int vacancyId, int applicantId)
        {
            var vacancyApplicant = await _context.VacancyApplicant
                .Include(v => v.Applicant)
                .Include(v => v.Location)
                .Include(v => v.Vacancy)
                .FirstOrDefaultAsync(m => m.VacancyId == vacancyId && m.ApplicantId == applicantId);

            if (vacancyApplicant == null)
            {
                return NotFound();
            }

            return View(vacancyApplicant);
        }

        // POST: VacancyApplicants/Delete/5/10
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int vacancyId, int applicantId)
        {
            var vacancyApplicant = await _context.VacancyApplicant
                .FirstOrDefaultAsync(m => m.VacancyId == vacancyId && m.ApplicantId == applicantId);

            if (vacancyApplicant != null)
            {
                _context.VacancyApplicant.Remove(vacancyApplicant);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> View_Submissions(int vacancyId)
        {
            var submissions = await _context.VacancyApplicant
                .Include(v => v.Applicant)
                .Where(v => v.VacancyId == vacancyId)
                .Select(v => new
                {
                    v.Applicant.ApplicantFirstName,
                    v.Applicant.ApplicantLastName,
                    v.Applicant.YearsOfExperience,
                    v.Applicant.ResumeFilePath,
                    v.Applicant.ApplicantId,
                    v.VacancyId
                })
                .ToListAsync();

            ViewBag.VacancyId = vacancyId; // Pass vacancyId to view if needed

            return View(submissions);
        }

        private bool VacancyApplicantExists(int vacancyId, int applicantId)
        {
            return _context.VacancyApplicant.Any(e => e.VacancyId == vacancyId && e.ApplicantId == applicantId);
        }
    }
}
