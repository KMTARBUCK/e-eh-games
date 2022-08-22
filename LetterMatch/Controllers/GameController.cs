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
        GameBuilder newWord = new GameBuilder("world");
        WordCombo wordCombo1 = newWord.Setup();
        /* Add wordCombo1 to an array, then just repeat
        (we can refactor this code later, just to prevent
        having to repeat every time we want a new word).
        
        Then add the array to the ViewBag, from which we
        can loop through them in the view and create buttons.
        
        Two buttons will be needed per wordCombo - one for
        the MissingLetters and one for the Incomplete Word, both
        of which should have the same value (which you can set
        to "comboname".FullWord). */
        return View();
    }

    [Route("/game")]
    [HttpPost]
    public RedirectResult Create(string incompleteWord, string missingLetters)
    {      
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
