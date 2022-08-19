namespace LetterMatch.Models;

public class WordChecker
{
  public static string Check(string value1, string value2)
  {
    if(CheckSelection(value1, value2) == false)
    {
      return "missing";
    }
    else if(value1 == value2)
    {
      return "correct";
    }
    else
    {
      return "incorrect";
    }
  }

  private static bool CheckSelection(string value1, string value2)
  {
    bool firstButton = string.IsNullOrEmpty(value1);
    bool secondButton = string.IsNullOrEmpty(value2);

    if(firstButton == true || secondButton == true)
    {
      return false;
    }
    else
    {
      return true;
    }
  }
}