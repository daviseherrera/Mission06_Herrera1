using Microsoft.EntityFrameworkCore;

namespace Mission06_Herrera.Models;

public class MovieSubmissionContext : DbContext
{
    public DbSet<Submission> Movies { get; set; }
    
    public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options) // Constructor
    {
    }
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) // Seeding data
    {
        modelBuilder.Entity<Category>().HasData(
        new Category {CategoryId = 1, CategoryName = "Miscellaneous"},
        new Category {CategoryId = 2, CategoryName = "Drama"},
        new Category {CategoryId = 3, CategoryName = "Television"},
        new Category {CategoryId = 4, CategoryName = "Horror/Suspense"},
        new Category {CategoryId = 5, CategoryName = "Comedy"},
        new Category {CategoryId = 6, CategoryName = "Family"},
        new Category {CategoryId = 7, CategoryName = "Action/Adventure"},
        new Category {CategoryId = 8, CategoryName = "VHS"});
            
    }
}