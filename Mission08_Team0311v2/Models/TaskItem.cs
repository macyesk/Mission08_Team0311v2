using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0311v2.Models;

public class TaskItem
{
    [Key]
    public int TaskId { get; set; }
    [Required]
    public string TaskName { get; set; }
    public string DueDate { get; set; }
    [Required]
    public int Quadrant { get; set; }
    public int Completed { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
    
}