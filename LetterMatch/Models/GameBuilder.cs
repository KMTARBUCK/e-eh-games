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
      SetIndexes(word);
      string upperCaseWord = word.ToUpper();
      WordCombo wordPair = new WordCombo();
      wordPair.FullWord = upperCaseWord;
      wordPair.MissingLetters = GetLetters(upperCaseWord);
      wordPair.IncompleteWord = Split(upperCaseWord);
      wordPair.Status = "incomplete";
      wordList.Add(wordPair);
    }
    WordCombo[] wordComboArray = wordList.ToArray();
    return wordComboArray;
  }

  public void SetIndexes(string word)
  {
    List<int> usedIndexes = new List<int>();
    this.index1 = rnd.Next(0, word.Length-1); //3
    usedIndexes.Add(index1); //usedIndexes now contains 3
    this.index2 = rnd.Next(0, word.Length-1); //3
    if (usedIndexes.Contains(this.index2)) //true
    {
      while(usedIndexes.Contains(this.index2))
      {
        this.index2 = rnd.Next(0, word.Length-1);
      }
      usedIndexes.Add(index2);
    }
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