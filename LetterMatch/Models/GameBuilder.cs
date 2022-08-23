namespace LetterMatch.Models;

public class GameBuilder
{
   int index1;
   int index2;
   Random rnd = new Random();

  public WordCombo[] Setup(string[] wordArray)
  {
    List<WordCombo> wordList = new List<WordCombo>();
    foreach(string word in wordArray){
      //if word is present in CompletedWords list
      this.index1 = 1;
      this.index2 = 3; //rnd.Next(0,4)
      WordCombo wordPair = new WordCombo();
      wordPair.FullWord = word.ToUpper();
      wordPair.MissingLetters = GetLetters(word.ToUpper());
      wordPair.IncompleteWord = Split(word.ToUpper());
      wordPair.Status = "incomplete";
      wordList.Add(wordPair);
    }
    WordCombo[] wordComboArray = wordList.ToArray();
    return wordComboArray;
  }

  public string GetLetters(string word)
  {
    return word[this.index1].ToString() + word[this.index2].ToString();
  }
  
  public string Split(string word)
  {
    System.Text.StringBuilder builder = new System.Text.StringBuilder();
    for(int i = 0; i < word.Length; i++)
    {
      char letter = word[i];
      if(i == this.index1 || i == this.index2)
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