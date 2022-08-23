using LetterMatch.Models;

public class Game
{
  [Key]
  public int Id {get; set;}
  public int? Level {get; set;}
  public int Words {get; set;}
}
