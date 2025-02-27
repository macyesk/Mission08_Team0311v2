using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0311v2.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
}