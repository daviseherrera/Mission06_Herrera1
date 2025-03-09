using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Herrera.Models;

public class Submission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate the ID
    public int MovieId { get; set; }
    [Required(ErrorMessage = "You must select a category.")]
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required(ErrorMessage = "You need to input a title.")]  // Ensures Title is required
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "You need to inlcude the year")]  // Ensures Year is required
    public int Year { get; set; }
    public string? Director { get; set; } = string.Empty;
    [Required]  // Ensures Rating is required
    public string Rating { get; set; } = string.Empty;
    public bool Edited { get; set; }   
    public string? LentTo { get; set; }  // Nullable (optional)
    [Required] public string CopiedToPlex { get; set; }
    public string? Notes { get; set; }   // Nullable (optional)
}