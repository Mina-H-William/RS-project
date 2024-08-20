﻿using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Identity;
using MVC3.Areas.Identity.Authorization;

namespace MVC3.Areas.Access.Controllers
{
    [Area("Access")]
    [Permission("Questions")]
    public class QuestionsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult getType()
        {
            var type = HttpContext.Session.GetString("QuestionType") ?? "";
            return Json(new { typedp = type });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActive(int id, bool active)
        {
            var question = await _context.questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            question.Active = active; // Update the Active status
            _context.questions.Update(question);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Questions_part(string type)
        {
            var model = new List<QuestionViewModel>();
            var Questions = await _context.questions.Where(q => q.Question_type == type).ToListAsync();
            foreach (var question in Questions)
            {
                var item = new QuestionViewModel()
                {
                    id = question.id,
                    Header = question.Header,
                    Answer_Type = question.Answer_Type,
                    Active = question.Active,
                    ChooseItems = question.ChooseItems ?? ""
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
                new SelectListItem { Value = "Choose", Text = "Choose" }
            }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create_question(QuestioninputViewModel model, string chooseitems)
        {
            if (ModelState.IsValid)
            {
                if (model.Answer_Type == "Choose")
                {
                    chooseitems = (chooseitems == null) ? "" : chooseitems;
                    string[] items = chooseitems.Split(',');
                    if (items.Length < 2)
                    {
                        ModelState.AddModelError("", "You must write at least two items");
                        model.AnswerTypeOptions = new List<SelectListItem>
                        {
                            new SelectListItem { Value = "Text", Text = "Text" },
                            new SelectListItem { Value = "Checkbox", Text = "Checkbox" },
                            new SelectListItem { Value = "Choose", Text = "Choose" }
                        };
                        return View(model);
                    }
                }
                var question = new question()
                {
                    Question_type = model.Question_type,
                    Header = model.Header,
                    Answer_Type = model.Answer_Type,
                    Active = model.Active,
                    ChooseItems = chooseitems
                };
                await _context.AddAsync(question);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
