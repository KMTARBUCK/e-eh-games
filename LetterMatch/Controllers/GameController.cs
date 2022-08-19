using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LetterMatch.Models;

namespace LetterMatch.Controllers;

public class GameController : Controller
{
    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger)
    {
        _logger = logger;
    }
    [Route("/game")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/game")]
    [HttpPost]
    public RedirectResult Create(string incompleteWord, string missingLetters)
    {
        // Console.WriteLine("This is the incomplete word:");
        // Console.WriteLine(incompleteWord);
        // Console.WriteLine("These are the missing letters:");
        // Console.WriteLine(missingLetters);        
        switch(WordChecker.Check(incompleteWord, missingLetters))
        {
            case "missing":
            return new RedirectResult("/game?result=missing");
            case "correct":
            return new RedirectResult("/game?result=correct");
            case "incorrect":
            return new RedirectResult("/game?result=incorrect");
            default:
            return new RedirectResult("/game?result=oops");
        }        
   
    }
    
    /*Side-note: we could try returning the View directly instead of
        the RedirectResult, as we could then keep the values and be able
        to target the radio buttons we had previously selected (allowing for
        styling e.g.: turning them red if they're wrong).

        Either way works, but it would be really good if we could do this ^
        You could also then just throw the message (correct, incorrect) into
        the ViewBag directly.
        */

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
