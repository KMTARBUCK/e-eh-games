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
      //string[] statusArray = {"complete", "incomplete", "complete", "incomplete", "complete"};
      //HttpContext.Session.SetString[]("wordStatuses", statusArray);
      GameBuilder newWord = new GameBuilder();
      // string[] wordArray = {"maker", "TaSkS", "Plays", "Apply", "ReacT"};
      LetterMatchDbContext dbContext = new LetterMatchDbContext();
      //string[] games = dbContext.Games.First(game.Words);
      Game currentLevel = dbContext.Games.Where(level => level.Level == 2).First();
      string[] wordArray = currentLevel.Words;
      System.Console.WriteLine(wordArray);
      //if session exists, then don't run this:
      WordCombo[] wordCombos = newWord.Setup(wordArray);
      //make session     
      ViewBag.wordCombos = wordCombos;
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
            //loop through words in this.wordCombos, if word = incompleteWord, then set word.Status to "correct"
            return new RedirectResult("/game?result=correct");
            case "incorrect":
            return new RedirectResult("/game?result=incorrect");
            default:
            return new RedirectResult("/game?result=oops");
        }        
    }

    [Route("/youwin")]
    [HttpPost]
    public RedirectResult YouWin()
    {
      return new RedirectResult("/game");
    }

    [Route("/newplayer")]
    [HttpPost]
    public RedirectResult NewPlayer()
    {
      //Set up session
      return new RedirectResult("/game");
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
