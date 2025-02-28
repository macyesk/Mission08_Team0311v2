using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0311v2.Models;
using System.Linq;

namespace Mission08_Team0311v2.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepo;
        private readonly TaskContext _context;

        public TaskController(ITaskRepository taskRepo, TaskContext context)
        {
            _taskRepo = taskRepo;
            _context = context;
        }

        // GET: /Task/Index
        // This action displays all tasks that are not completed.
        public IActionResult Index()
        {
            // Only show tasks that are not completed 
            var tasks = _taskRepo.Tasks.Where(t => t.Completed == 0).ToList();
            return View(tasks);
        }

        // GET: /Task/Create
        // This action shows the form to add a new task.
        public IActionResult Create()
        {
            // Retrieve the list of categories from the database.
            ViewBag.Categories = _context.Categories.ToList();
            return View("CreateTask");
        }

        // POST: /Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _taskRepo.AddTask(task);
                return RedirectToAction("Index");
            }
            // If model validation fails, repopulate the categories.
            ViewBag.Categories = _context.Categories.ToList();
            return View("CreateTask", task);
        }

        // GET: /Task/Edit/{id}
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(task);
        }

        // POST: /Task/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(task);
        }

        // GET: /Task/Delete/{id}
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: /Task/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: /Task/MarkCompleted/{id}
        public IActionResult MarkCompleted(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            task.Completed = 1;  // Mark task as completed.
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
