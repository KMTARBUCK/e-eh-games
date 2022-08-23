namespace LetterMatch.Tests;
using LetterMatch.Models;

public class GameBuilderTest
{
  [Test]
  public void GameBuilder_PassArrayOfOneWord_Return_FullWord_IncompleteWord_MissingLetters()
    {
      GameBuilder newWord = new GameBuilder();
      string[] wordArray = {"world"};
      WordCombo[] wordCombos = newWord.Setup(wordArray);
      Assert.AreEqual("world", wordCombos[0].FullWord);
      Assert.AreEqual("w_r_d", wordCombos[0].IncompleteWord);
      Assert.AreEqual("ol", wordCombos[0].MissingLetters);
    }

  [Test]
  public void GameBuilder_PassArrayOfTwoWords_Return_CorrectItems()
    {
      GameBuilder newWord = new GameBuilder();
      string[] wordArray = {"world", "setup"};
      WordCombo[] wordCombos = newWord.Setup(wordArray);
      Assert.AreEqual("world", wordCombos[0].FullWord);
      Assert.AreEqual("w_r_d", wordCombos[0].IncompleteWord);
      Assert.AreEqual("ol", wordCombos[0].MissingLetters);
      Assert.AreEqual("setup", wordCombos[1].FullWord);
      Assert.AreEqual("s_t_p", wordCombos[1].IncompleteWord);
      Assert.AreEqual("eu", wordCombos[1].MissingLetters);
    }
}