namespace LetterMatch.Models;

public class WordChecker
{
  public static bool Check(string value1, string value2)
  {
    if(value1 == value2)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}