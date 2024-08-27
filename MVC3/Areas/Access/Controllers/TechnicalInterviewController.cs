using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using MVC3.Areas.Access.Models;
using MVC3.Areas.Access.ViewModels;
using MVC3.Areas.Identity.Models;
using MVC3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC3.Areas.Access.Controllers
{
    [Area("Access")]
    //add permission and create it in database
    public class TechnicalInterviewController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public TechnicalInterviewController(ApplicationDbContext _dbcontext, UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            this._dbcontext = _dbcontext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;

            var applicantVacancies = await _dbcontext.TechnicalInterviews
            .Where(av => av.TechnicalInterviewer == userName)
            .Select(av => new
            {
                av.ApplicantId,
                av.VacancyId,
                av.Done
            })
            .ToListAsync();

            List<TechnicalInteviewViewModel> model = new List<TechnicalInteviewViewModel>();

            foreach(var a in applicantVacancies)
            {
                var applicant = _dbcontext.Applicant.Where(ap=>ap.ApplicantId==a.ApplicantId)
                                                    .FirstOrDefault();
                var vacancy = _dbcontext.Vacancy.Where(v => v.VacancyId == a.VacancyId).Include(v=>v.Title)
                                                    .FirstOrDefault();
                TechnicalInteviewViewModel tv = new TechnicalInteviewViewModel()
                {
                    Applicantid = a.ApplicantId,
                    Applicant = applicant,
                    Vacancyid = a.VacancyId,
                    Vacancy = vacancy,
                    Done = a.Done
                };
                model.Add(tv);
            };

            return View(model);
        }

        public async Task<IActionResult> TechnicalQuestions(int applicantid, int vacancyid)
        {
            var questions = await _dbcontext.questions
                .Where(q => q.Question_type == "Technical" && q.Active)
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
                VacancyId = vacancyid,
                Questions = questionsview
            };


            ViewBag.submit = false;

            // Pass the questions to the view
            return View(allquestionview);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitTechnicalQuestions(allQuestionEvaluateViewModel model)
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
            return View("TechnicalQuestions", model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve_Technical(allQuestionEvaluateViewModel model)
        {
            var applicantstatus = await _dbcontext.ApplicantStatus
                .FirstOrDefaultAsync(ap => ap.ApplicantId == model.ApplicantId
                                     && ap.VacancyId == model.VacancyId);

            var TechnicalInterview = await _dbcontext.TechnicalInterviews.FirstOrDefaultAsync(tv=> tv.ApplicantId==model.ApplicantId
                                                                                        && tv.VacancyId==model.VacancyId);

            if (applicantstatus != null)
            {
                applicantstatus.Technical_rating = model.final_ration;
                applicantstatus.Technical = true;
                applicantstatus.Status = "approved";

                TechnicalInterview.Done = true;

                await _dbcontext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DisApprove_Technical(allQuestionEvaluateViewModel model)
        {
            var applicantstatus = await _dbcontext.ApplicantStatus
                .FirstOrDefaultAsync(ap => ap.ApplicantId == model.ApplicantId
                                     && ap.VacancyId == model.VacancyId);

            var TechnicalInterview = await _dbcontext.TechnicalInterviews.FirstOrDefaultAsync(tv => tv.ApplicantId == model.ApplicantId
                                                                                       && tv.VacancyId == model.VacancyId);

            if (applicantstatus != null)
            {
                applicantstatus.Technical_rating = model.final_ration;
                applicantstatus.Technical = true;
                applicantstatus.Status = "Disapproved";

                TechnicalInterview.Done = true;

                await _dbcontext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
