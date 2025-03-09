using System.ComponentModel.DataAnnotations;

namespace Mission06_Herrera.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required]
    public string CategoryName { get; set; } = string.Empty;
    
    public List<Submission> Submissions { get; set; } = new List<Submission>();
}