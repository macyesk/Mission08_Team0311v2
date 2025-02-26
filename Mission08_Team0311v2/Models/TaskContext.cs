using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0311.Models;

public class TaskContext :DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
        
    }
    
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
}