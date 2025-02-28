using Mission08_Team0311v2.Models;



namespace Mission08_Team0311v2.Models;

public class EFTaskRepository : ITaskRepository
{
    private TaskContext _context;

    public EFTaskRepository(TaskContext temp)
    {
        _context = temp;
    }

    public List<TaskItem> Tasks
{
    get
    {
        var tasks = _context.Tasks.ToList(); // Fetch tasks from the database

        // Check if tasks are empty and add test data for development purposes
        if (!tasks.Any())
        {
                tasks.Add(new TaskItem
                {
                    TaskId = 1,
                    TaskName = "Dummy Data Task",
                    DueDate = "2025-03-01",
                    Quadrant = 1,
                    Completed = 0,
                    CategoryId = 1
                });

                tasks.Add(new TaskItem
                {
                    TaskId = 2,
                    TaskName = "Dummy Task 2",
                    DueDate = "2025-03-05",
                    Quadrant = 2,
                    Completed = 0,
                    CategoryId = 1
                });
            }

        return tasks;
    }
}
    public List<Category> Categories => _context.Categories.ToList();
    
    public void AddTask(TaskItem task)
    {
        _context.Add(task);
        _context.SaveChanges();
    }
    public void UpdateTask(TaskItem task)
    {
        var existingTask = _context.Tasks.FirstOrDefault(x => x.TaskId == task.TaskId);
        if (existingTask != null)
        {
            // Update the properties of the existing task with the new task values
            existingTask.TaskName = task.TaskName;
            existingTask.DueDate = task.DueDate;
            existingTask.Quadrant = task.Quadrant;
            existingTask.Completed = task.Completed;
            existingTask.CategoryId = task.CategoryId;

            // Save the changes to the database
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Task not found");
        }

    }
    public void DeleteTask(int id)
    {
        // Find the task to delete
        var taskToDelete = _context.Tasks.FirstOrDefault(t => t.TaskId == id);

        if (taskToDelete != null)
        {
            // Remove the task from the context
            _context.Tasks.Remove(taskToDelete);

            // Save changes to the database
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Task not found.");
        }
    }
}