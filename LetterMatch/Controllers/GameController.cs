using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LetterMatch.Models;
using Microsoft.Extensions.Caching.Memory;

namespace LetterMatch.Controllers;

public class GameController : Controller
{
    private readonly ILogger<GameController> _logger;
    private IMemoryCache _cache;
    public GameController(ILogger<GameController> logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _cache = memoryCache;
    }
    [Route("/game")]
    [HttpGet]
    public IActionResult Index()
    {
      string resultInfo = HttpContext.Request.Query["result"];
      switch(resultInfo) 
      {
        case "missing":
          ViewBag.Message = "Select a pair and click play!";
          break;
        case "correct":
          ViewBag.Message = "Well done!";
          break;
        case "incorrect":
          ViewBag.Message = "Try again!";
          break;
        case "oops":
          ViewBag.Message = "Oops! Something went wrong!";
          break;
      }
      GameBuilder newWord = new GameBuilder();
      LetterMatchDbContext dbContext = new LetterMatchDbContext();
      Player currentUser = dbContext.Players.Where(player => player.Id == HttpContext.Session.GetInt32("player_id")).First();
      Game setLevel = dbContext.Games.Where(level => level.Level == currentUser.CurrentLevel).First();
      string[] wordArray = setLevel.Words;
      //if session exists, then don't run this:
      if(HttpContext.Session.GetString("status") == "requires_setup"){
        WordCombo[] wordCombos = newWord.Setup(wordArray);
        _cache.Set("wordComboOrder", wordCombos);
        HttpContext.Session.SetString("status", "running");
      }
      ViewBag.playerName = HttpContext.Session.GetString("player");
      ViewBag.wordCombos = _cache.Get("wordComboOrder");
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
              WordCombo[]? wordCombos = _cache.Get("wordComboOrder") as WordCombo[];
              foreach(WordCombo combo in wordCombos){
                if(combo.FullWord == incompleteWord)
                {
                  combo.Status = "correct";
                }
              }
              _cache.Set("wordComboOrder", wordCombos);
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
      LetterMatchDbContext dbContext = new LetterMatchDbContext();
      Player currentUser = dbContext.Players.Where(player => player.Id == HttpContext.Session.GetInt32("player_id")).First();
      currentUser.CurrentLevel += 1;
      dbContext.Update(currentUser);
      dbContext.SaveChanges();
      HttpContext.Session.SetString("status", "requires_setup");
      return new RedirectResult("/game");
    }

    [Route("/newplayer")]
    [HttpPost]
    public RedirectResult NewPlayer(string playerName)
    {
      bool nameEmpty = string.IsNullOrEmpty(playerName);
      if(nameEmpty == true)
      {
        return new RedirectResult("/?name=missing");
      }
      Player newplayer = new Player();
      newplayer.Name = playerName;
      newplayer.CurrentLevel = 1;
      LetterMatchDbContext dbContext = new LetterMatchDbContext();
      dbContext.Players.Add(newplayer);
      dbContext.SaveChanges();
      HttpContext.Session.SetString("player", newplayer.Name);
      HttpContext.Session.SetInt32("player_id", newplayer.Id);
      HttpContext.Session.SetString("status", "requires_setup");
      return new RedirectResult("/game");
    }


    // [Route("/game")]
    // [HttpGet]
    // public IActionResult New()
    // {
    //   string resultInfo = HttpContext.Request.Query["result"];
    //   switch(resultInfo) 
    //   {
    //     case "missing":
    //       ViewBag.Message = "Select a pair and click play!";
    //       break;
    //     case "correct":
    //       ViewBag.Message = "Well done!";
    //       break;
    //     case "incorrect":
    //       ViewBag.Message = "Try again!";
    //       break;
    //     case "oops":
    //       ViewBag.Message = "Oops! Something went wrong!";
    //       break;
    //   }

    //   // ViewBag.status = WordChecker.Check(HttpContext.Session.GetString("user_id"));
    //   return View();
    // }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
