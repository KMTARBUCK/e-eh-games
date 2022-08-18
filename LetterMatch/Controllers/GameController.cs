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
    public RedirectResult Create(/*string value1, string value2*/)
    {
        //switch(WordChecker.check(value1, value2))
        //{
        //case true:
        //return new RedirectResult("/game?word=correct")
        //case false:
        //return new RedirectResult("/game?word=incorrect")
        //}

        /*Side-note: we could try returning the View directly instead of
        the RedirectResult, as we could then keep the values and be able
        to target the radio buttons we had previously selected (allowing for
        styling e.g.: turning them red if they're wrong).

        Either way works, but it would be really good if we could do this ^
        You could also then just throw the message (correct, incorrect) into
        the ViewBag directly.
        */
        return new RedirectResult("/game");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
