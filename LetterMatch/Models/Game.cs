using LetterMatch.Models;

public class Game
{
  [Key]
  public int Id {get; set;}
  public int? Level {get; set;}
  public int UserId {get; set;}
  public DateTime DateTimePosted {get; set;}
  public int Likes {get; set;}
  public User? User {get; set;}
}
