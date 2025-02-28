using Mission08_Team0311v2.Models;



namespace Mission08_Team0311v2.Models;

public class EFTaskRepository : ITaskRepository
{
    private TaskContext _context;

    public EFTaskRepository(TaskContext temp)
    {
        _context = temp;
    }

    public List<TaskItem> Tasks => _context.Tasks.ToList();
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