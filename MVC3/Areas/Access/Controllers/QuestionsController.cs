using Microsoft.AspNetCore.Mvc;
using MVC3.Data;
using MVC3.Areas.Access.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MVC3.Areas.Access.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC3.Areas.Access.Controllers
{
    [Area("Access")]
    public class QuestionsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Questions_part(string type)
        {
            var model = new List<ViewModelQuestion>();
            var hR_Questions = await _context.questions.Where(q => q.Question_type == type).ToListAsync();
            foreach (var question in hR_Questions)
            {
                var item = new ViewModelQuestion()
                {
                    id = question.id,
                    Header = question.Header,
                    Answer_Type = question.Answer_Type,
                    Active = question.Active
                };
                model.Add(item);
            }
            HttpContext.Session.SetString("QuestionType", type);
            return PartialView("QuestionsPartial", model);
        }

        [HttpGet]
        public IActionResult Create_question()
        {
            var type = HttpContext.Session.GetString("QuestionType");
            var model = new QuestioninputViewModel()
            {
                Question_type = type,
                AnswerTypeOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Text", Text = "Text" },
                new SelectListItem { Value = "Checkbox", Text = "Checkbox" },
                new SelectListItem { Value = "Range", Text = "Range" }
            }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create_question(QuestioninputViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = new question()
                {
                    Question_type = model.Question_type,
                    Header = model.Header,
                    Answer_Type = model.Answer_Type,
                    Active = model.Active
                };
                await _context.AddAsync(question);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
