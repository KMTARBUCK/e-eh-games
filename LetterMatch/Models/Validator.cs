namespace LetterMatch.Models;

public class Validator
{
  
  public static bool CheckSelection(string value1, string value2)
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