using LetterMatch.Models;
using System.ComponentModel.DataAnnotations;

public class Game
{
  [Key]
  public int Id {get; set;}
  public int? Level {get; set;}
  public string[]? Words {get; set;}
}
