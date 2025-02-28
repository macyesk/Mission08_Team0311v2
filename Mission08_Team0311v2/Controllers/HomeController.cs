using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0311v2.Models;

namespace Mission08_Team0311v2.Controllers;

public class HomeController : Controller
{
    private readonly ITaskRepository _repo;

    // Constructor injection of the repository
    public HomeController(ITaskRepository repo)
    {
        _repo = repo;
    }
    public IActionResult Index()
    {
        // tasks may be null
        List<TaskItem> ? tasks = _repo.Tasks;

        // Return the view with the tasks model
        return View(tasks);
    }
    public IActionResult CreateTask()
    {
        List<Category> ? categories = _repo.Categories;
        ViewBag.Categories = categories;
        return View(new TaskItem());
    }
    [HttpPost]
    public IActionResult CreateTask(TaskItem task)
    {
        _repo.AddTask(task);
        // Redirect to the Index action after adding the task
        return RedirectToAction("Index");
    }
}