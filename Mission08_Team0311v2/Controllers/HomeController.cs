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
    [HttpGet]
    public IActionResult CreateTask(TaskItem task)
    {
        List<Category> ? categories = _repo.Categories;
        ViewBag.Categories = categories;
        return View(task ?? new TaskItem());
    }
    [HttpPost]
    public IActionResult AddTask(TaskItem task)
    {
        _repo.AddTask(task);
        // Redirect to the Index action after adding the task
        return RedirectToAction("Index");
    }
    public IActionResult UpdateTask(TaskItem task)
    {
        _repo.UpdateTask(task);
        return RedirectToAction("Index");
    }
    public IActionResult DeleteTask(int taskId)
    {
        _repo.DeleteTask(taskId);
        return RedirectToAction("Index");
    }
}