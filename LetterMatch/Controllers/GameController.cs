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
    public RedirectResult Create()
    {
        return new RedirectResult("/game");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
