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
    
    public void AddTask(TaskItem task)
    {
        _context.Add(task);
        _context.SaveChanges();
    }

}