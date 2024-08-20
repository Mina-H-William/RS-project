using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC3.Areas.Access.ViewModels;
using MVC3.Areas.Access.Models;
using MVC3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC3.Areas.Access.Controllers
{
    [Area("Access")]
    // add permission
    public class InterviewEvaluateController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public InterviewEvaluateController(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        //  in future edit submit and edit question answer /////
        public IActionResult get_HR_submit()
        {
            return View();
        }

        public IActionResult HRQuestions(int applicantid, int vid)
        {
            // Fetch active HR questions
            var questions = _dbcontext.questions
                .Where(q => q.Question_type == "HR" && q.Active)
                .ToList();

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
                var ApplicantAnswer = new ApplicantAnswers()
                {
                    ApplicantId = model.ApplicantId,
                    VacancyId = model.VacancyId,
                    QuestionId = question.QuestionId,
                    Answer = question.Answer
                };
                await _dbcontext.ApplicantAnswers.AddAsync(ApplicantAnswer);
            }
            await _dbcontext.SaveChangesAsync();

            ViewBag.submit = true;
            // Redirect or show a success message
            return View("HRQuestions",model);
        }

        public async Task<IActionResult> Approve_HR(allQuestionEvaluateViewModel model)
        {
            return View();
        }

        public async Task<IActionResult> DisApprove_HR(allQuestionEvaluateViewModel model)
        {
            return View();
        }
    }
}
