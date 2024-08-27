using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC3.Areas.Access.ViewModels;
using MVC3.Areas.Access.Models;
using MVC3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVC3.Areas.Identity.Models;

namespace MVC3.Areas.Access.Controllers
{
    [Area("Access")]
    //add permission and create it in database
    public class InterviewEvaluateController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<ApplicationUser> userManager;


        public InterviewEvaluateController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _dbcontext = context;
            this.userManager = userManager;
        }

        //  in future edit submit and edit question answer /////
        /*public IActionResult get_HR_submit()
        {
            return View();
        }*/

        public async Task<IActionResult> HRQuestions(int applicantid, int vid)
        {
            // Fetch active HR questions
            var questions = await _dbcontext.questions
                .Where(q => q.Question_type == "HR" && q.Active)
                .ToListAsync();

            var questionsview = new List<QuestionEvaluateViewModel>();

            foreach (var question in questions)
            {
                string[] chooseitems = new string[] { "" };
                if (question.ChooseItems != null)
                    chooseitems = question.ChooseItems.Split(',');
                var questionview = new QuestionEvaluateViewModel()
                {
                    QuestionId = question.id,
                    Header = question.Header,
                    AnswerType = question.Answer_Type,
                    ChooseItems = chooseitems
                };
                questionsview.Add(questionview);
            }

            var allquestionview = new allQuestionEvaluateViewModel()
            {
                ApplicantId = applicantid,
                VacancyId = vid,
                Questions = questionsview
            };


            ViewBag.submit = false;

            // Pass the questions to the view
            return View(allquestionview);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitHRQuestions(allQuestionEvaluateViewModel model)
        {
            foreach (var question in model.Questions)
            {
                // Check if the record exists
                var existingApplicantAnswer = await _dbcontext.ApplicantAnswers
                    .FirstOrDefaultAsync(a => a.ApplicantId == model.ApplicantId
                                           && a.VacancyId == model.VacancyId
                                           && a.QuestionId == question.QuestionId);

                if (existingApplicantAnswer != null)
                {
                    // Update existing record
                    existingApplicantAnswer.Answer = question.Answer ?? "";
                    _dbcontext.ApplicantAnswers.Update(existingApplicantAnswer);
                }
                else
                {
                    // Create a new record
                    var applicantAnswer = new ApplicantAnswers()
                    {
                        ApplicantId = model.ApplicantId,
                        VacancyId = model.VacancyId,
                        QuestionId = question.QuestionId,
                        Answer = question.Answer ?? ""
                    };
                    await _dbcontext.ApplicantAnswers.AddAsync(applicantAnswer);
                }
            }
            await _dbcontext.SaveChangesAsync();

            ViewBag.submit = true;
            // Redirect or show a success message
            return View("HRQuestions", model);
        }

        [HttpGet]
        public async Task<IActionResult> ChooseTechnical(int applicantId, int vacancyId)
        {
            var depid = await _dbcontext.Vacancy
                .Where(v => v.VacancyId == vacancyId)
                .Select(v => v.Title.DepartmentId)
                .FirstOrDefaultAsync();

            var departmentname = await _dbcontext.Department
                                .Where(d => d.DepartmentId == depid)
                                .Select(d => d.DepartmentName)
                                .FirstOrDefaultAsync();

            var usersid = await _dbcontext.UserDepartmentProject
                .Where(d => d.DepartmentId == depid)
                .Select(u => u.UserId)
                .Distinct()
                .ToListAsync();

            var usersinfo = await userManager.Users
                .Where(u => usersid.Contains(u.Id) && u.Active)
            .Include(u => u.UserDepartmentProject)
                .ThenInclude(udp => udp.Project)
            .ToListAsync();

            var model = new ChooseTechnicalViewModel()
            {
                departmentname = departmentname,
                Users = usersinfo,
                Applicantid = applicantId,
                Vacancyid = vacancyId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendToTechnical(ChooseTechnicalViewModel model, string userId)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userId);
                var technicalinterview = new TechnicalInterview()
                {
                    ApplicantId = model.Applicantid,
                    VacancyId = model.Vacancyid,
                    TechnicalInterviewer = user.UserName
                };
                await _dbcontext.AddAsync(technicalinterview);
                await _dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("ViewSubmissions", "Vacancies",new {Id = model.Vacancyid});
        }

        [HttpPost]
        public async Task<IActionResult> Approve_HR(allQuestionEvaluateViewModel model)
        {
            var applicantstatus = await _dbcontext.ApplicantStatus
                .FirstOrDefaultAsync(ap => ap.ApplicantId == model.ApplicantId
                                     && ap.VacancyId == model.VacancyId);

            if (applicantstatus != null)
            {
                applicantstatus.HR_Rating = model.final_ration;
                applicantstatus.HR = true;
                await _dbcontext.SaveChangesAsync();
            }

            return RedirectToAction("ChooseTechnical", new { applicantId = model.ApplicantId, vacancyId = model.VacancyId });
        }

        [HttpPost]
        public async Task<IActionResult> DisApprove_HR(allQuestionEvaluateViewModel model)
        {
            var applicantstatus = await _dbcontext.ApplicantStatus
                .FirstOrDefaultAsync(ap => ap.ApplicantId == model.ApplicantId
                                     && ap.VacancyId == model.VacancyId);

            if (applicantstatus != null)
            {
                applicantstatus.HR_Rating = model.final_ration;
                applicantstatus.HR = true;
                applicantstatus.Status = "Disapproved";
                await _dbcontext.SaveChangesAsync();
            }

            return RedirectToAction("ViewSubmissions", "Vacancies", new { Id = model.VacancyId });
        }
    }
}
