namespace LetterMatch.Models;

public class GameBuilder
{
   int index1;
   int index2;
   string word;
  public GameBuilder(string word)
  {
    this.index1 = 1;
    this.index2 = 3;
    this.word = word;
    Setup(word);
  }

  public WordCombo Setup(string word)
  {
    WordCombo wordPair = new WordCombo();
    wordPair.FullWord = word;
    wordPair.MissingLetters = GetLetters(word);
    wordPair.IncompleteWord = Split(word);
    wordPair.Status = "incomplete";
    return wordPair;
  }

  public string GetLetters(string word)
  {
    return word[this.index1].ToString() + word[this.index2].ToString();
  }
  public string Split(string word)
  {
    System.Text.StringBuilder builder = new System.Text.StringBuilder();
    foreach(char letter in word)
    {
      if(letter == word[this.index1] || letter == word[this.index2])
      {
        builder.Append("_");
      }
      else{
        builder.Append(letter);
      }
    }
    return builder.ToString();
  }
}