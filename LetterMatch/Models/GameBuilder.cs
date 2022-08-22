namespace LetterMatch.Models;

public class GameBuilder
{
   int index1;
   int index2;
   string[] wordArray = new string[5];
  //  WordCombo[] objectArray = new WordCombo[5];

  public GameBuilder(string[] wordArray)
  {
    this.index1 = 1;
    this.index2 = 3;
    this.wordArray = wordArray;
    // this.objectArray = objectArray;
  }
// pass in an array of words, return an array of object
// create a db columns for id, level, words (array), date?
// Adapt method to take array of strings. Return an array of objects
// Add viewbags to controller. Iterate through on index pa 
  public WordCombo[] Setup()
  
  {
    // WordCombo[] objectArray = new WordCombo[5];

    foreach (string word in this.wordArray)
    {
      WordCombo wordPair = new WordCombo();
      wordPair.FullWord = word;
      wordPair.MissingLetters = GetLetters(word);
      wordPair.IncompleteWord = Split(word);
      wordPair.Status = "incomplete";
      objectArray = objectArray.Append(wordPair).ToArray();
    }
    return objectArray;

// List<Subject> allDestek = new List<Subject>() {
//    new Subject(){ ID = 1, Name = "aaaa"},
//    new Subject(){ ID = 2, Name = "bbbb"},
//    new Subject(){ ID = 2, Name = "cccc"},
//    new Subject(){ ID = 2, Name = "dddd"}
//  };

//  allSubject.ToArray()


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