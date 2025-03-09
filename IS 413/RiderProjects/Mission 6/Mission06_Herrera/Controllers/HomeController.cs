using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Mission06_Herrera.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mission06_Herrera.Controllers;

public class HomeController : Controller
{
    private MovieSubmissionContext _context;
    
    public HomeController(MovieSubmissionContext temp) // Constructor
    {
        _context = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult MovieSubmission()
    {
        ViewBag.Categories = _context.Categories.ToList();
            
        return View("MovieSubmission", new Submission());
    }
    
    [HttpPost]
    public IActionResult MovieSubmission(Mission06_Herrera.Models.Submission response)
    {
        Console.WriteLine($"Received CategoryId: {response.CategoryId}"); // Debugging

        // Ensure LentTo is never NULL
        response.LentTo = string.IsNullOrWhiteSpace(response.LentTo) ? null : response.LentTo;
        response.Notes = string.IsNullOrWhiteSpace(response.Notes) ? null : response.Notes;

        response.MovieId = 0;

        if (!ModelState.IsValid)
        {
            Console.WriteLine("ModelState is invalid.");
            foreach (var error in ModelState)
            {
                Console.WriteLine($"Key: {error.Key}, Errors: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
            }
            ViewBag.Categories = _context.Categories.ToList(); // Keep dropdown populated
            return View(response); // Return the form with validation messages
        }

        _context.Movies.Add(response);
        _context.SaveChanges();

        return View("Confirmation", response);
    }

    public IActionResult MovieList()
    {
        var submissions = _context.Movies
            .OrderBy(x => x.Title)
            .ToList();

        return View(submissions);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("MovieSubmission", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Submission updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Submission response)
    {
        _context.Movies.Remove(response);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
}