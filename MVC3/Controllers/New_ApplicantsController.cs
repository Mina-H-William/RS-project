using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC3.Data;
using MVC3.Areas.Access.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace MVC3.Controllers
{
    public class New_ApplicantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _resumeFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes");

        public New_ApplicantsController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: New_Applicants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applicant.ToListAsync());
        }

        // GET: New_Applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicant
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: New_Applicants/Create
        public async Task<IActionResult> Create(int VacancyId)
        {
            var vacany = await _context.Vacancy.FirstOrDefaultAsync(v=>v.VacancyId == VacancyId);
            ViewBag.vacancyname = vacany.VacancyName;
            ViewBag.VacancyId = VacancyId;
            ViewBag.Nationalities = new SelectList(_context.Nationalities, "Id", "Name");
            var jsonModel = HttpContext.Session.GetString("applicant");
            if (!string.IsNullOrEmpty(jsonModel))
            {
                var applicant = JsonConvert.DeserializeObject<Applicant>(jsonModel);
                string absolutePath = Path.Combine(_webHostEnvironment.WebRootPath, applicant.ResumeFilePath.TrimStart('/'));
                if (System.IO.File.Exists(absolutePath))
                {
                    // Delete the file
                    System.IO.File.Delete(absolutePath);
                }
                return View(applicant);
            }
            return View();
        }

        // POST: New_Applicants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantId,ApplicantFirstName,ApplicantMiddleName,ApplicantLastName,DateOfBirth," +
            "EmailAddress,ContactNumber,HomeAddress1,Address2,Nationality,Gender,MilitaryStatus,MaritalStatus,CertificateName,GraduationYear" +
            ",Major,University,CurrentEmployer,CurrentPosition,CurrentSalary,YearsOfExperience,NoticePeriod,ExtraCertificates")]
            Applicant applicant, int VacancyId, IFormFile ResumeFile)
        {
            if (ModelState.IsValid)
            {
                var existingApplicant = await _context.Applicant
                    .FirstOrDefaultAsync(a => a.EmailAddress == applicant.EmailAddress && a.ContactNumber == applicant.ContactNumber);

                if (existingApplicant != null)
                {
                    ModelState.AddModelError(string.Empty, "An applicant with the same email address and contact number already exists.");
                    ViewBag.VacancyId = VacancyId;
                    return View(applicant);
                }

                if (ResumeFile != null && ResumeFile.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + ResumeFile.FileName;
                    var filePath = Path.Combine(_resumeFolderPath, uniqueFileName);

                    if (!Directory.Exists(_resumeFolderPath))
                    {
                        Directory.CreateDirectory(_resumeFolderPath);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ResumeFile.CopyToAsync(fileStream);
                    }

                    applicant.ResumeFilePath = "/resumes/" + uniqueFileName;
                }
                else
                {
                    ModelState.AddModelError("", "CV Required");
                    ViewBag.VacancyId = VacancyId;
                    ViewBag.Nationalities = new SelectList(_context.Nationalities, "Id", "Name");
                    return View(applicant);
                }


                var jsonModel = JsonConvert.SerializeObject(applicant);

                // Store the JSON string in TempData
                HttpContext.Session.SetString("applicant", jsonModel);

                //_context.Add(applicant);
                //await _context.SaveChangesAsync();

                return RedirectToAction("Create", "VacancyApplicants", new { vacancyId = VacancyId });
            }
            ViewBag.VacancyId = VacancyId;
            return View(applicant);
        }

        [HttpPost]
        public async Task<IActionResult> CheckExistingApplicant(string email, string phone)
        {
            var existingApplicant = await _context.Applicant
                .FirstOrDefaultAsync(a => a.EmailAddress == email || a.ContactNumber == phone);

            if (existingApplicant != null)
            {
                return Json(existingApplicant);
            }

            return Json(null);
        }

        public IActionResult RedirectToVacancyApplicantCreate(int applicantId, int vacancyId)
        {
            return RedirectToAction("Create", "VacancyApplicants", new { applicantId = applicantId, vacancyId = vacancyId });
        }

        // GET: New_Applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicant.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: New_Applicants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantId,ApplicantFirstName,ApplicantMiddleName,ApplicantLastName,DateOfBirth," +
            "EmailAddress,ContactNumber,HomeAddress1,Address2,Nationality,Gender,MilitaryStatus,MaritalStatus,CertificateName,GraduationYear," +
            "Major,University,CurrentEmployer,CurrentPosition,CurrentSalary,YearsOfExperience,NoticePeriod,ExtraCertificates")]
            Applicant applicant)
        {
            if (id != applicant.ApplicantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(applicant.ApplicantId))
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
            return View(applicant);
        }

        // GET: New_Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.Applicant
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: New_Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _context.Applicant.FindAsync(id);
            _context.Applicant.Remove(applicant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantExists(int id)
        {
            return _context.Applicant.Any(e => e.ApplicantId == id);
        }
    }
}
