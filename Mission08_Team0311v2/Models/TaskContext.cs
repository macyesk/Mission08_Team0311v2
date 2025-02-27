using Microsoft.EntityFrameworkCore;
using Mission08_Team0311v2.Models;

namespace Mission08_Team0311v2.Models;

public class TaskContext :DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
        
    }
    
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
}