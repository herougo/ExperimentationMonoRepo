using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using QuestionBank.Controllers.ReturnResults;
using QuestionBank.Data;
using QuestionBank.DataLogic;
using QuestionBank.Models;

namespace QuestionBank.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DoneTag _doneTag;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
            _doneTag = new DoneTag(context);

        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
              return _context.Question != null ? 
                          View(await _context.Question.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Question'  is null.");
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Create
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid ModelState");
            }
            StreamReader requestReader = new StreamReader(Request.Body);
            JObject request = JObject.Parse(await requestReader.ReadToEndAsync());
            Question question = new Question()
            {
                QuestionText = request["QuestionText"]?.ToString(),
                AnswerText = request["AnswerText"]?.ToString()
            };

            _context.Add(question);
            await _context.SaveChangesAsync();
            return new EmptyResult();

        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionText,AnswerText")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Question == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Question == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Question'  is null.");
            }
            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
          return (_context.Question?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<FilteredQuestionReturnResult> Filtered()
        {
            string currentUserId = HttpContext.User.FindFirstValue("userID");
            HashSet<int> doneQuestionIds = _doneTag.GetDoneQuestionIds(currentUserId).ToHashSet<int>();
            return _context.Question.Select(x => new FilteredQuestionReturnResult
            {
                Id = x.Id,
                QuestionText = x.QuestionText,
                AnswerText = x.AnswerText,
                Done = doneQuestionIds.Contains(x.Id),
                Courses = "",
                Tags = ""
            })
            .ToArray();
        }

        [Authorize]
        [HttpPost]
        public IActionResult MarkAsDone(int id)
        {
            string currentUserId = HttpContext.User.FindFirstValue("userID");
            _doneTag.MarkAsDone(id, currentUserId);
            return new EmptyResult();
        }

        [Authorize]
        [HttpPost]
        public IActionResult MarkAsNotDone(int id)
        {
            string currentUserId = HttpContext.User.FindFirstValue("userID");
            _doneTag.MarkAsNotDone(id, currentUserId);
            return new EmptyResult();
        }
    }
}
