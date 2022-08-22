namespace LetterMatch.Tests;
using LetterMatch.Models;

public class GameBuilderTest
{
  [Test]
  public void CheckGameBuilderSetup_ManuallyPassWord_ReturnFullWordIncompleteWordMissingLetters()
    {
      GameBuilder newWord = new GameBuilder("world");
      WordCombo wordCombo1 = newWord.Setup();
      Assert.AreEqual("world", wordCombo1.FullWord);
      Assert.AreEqual("w_r_d", wordCombo1.IncompleteWord);
      Assert.AreEqual("ol", wordCombo1.MissingLetters);
    }
}