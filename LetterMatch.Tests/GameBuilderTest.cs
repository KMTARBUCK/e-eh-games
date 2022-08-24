namespace LetterMatch.Tests;
using LetterMatch.Models;

// public class GameBuilderTest
// {
//   [Test] COMMENTED OUT AS IT NEEDS TO BE MOCKED
//   public void GameBuilder_PassArrayOfOneWord_Return_FullWord_IncompleteWord_MissingLetters()
//     {
//       GameBuilder newWord = new GameBuilder();
//       string[] wordArray = {"WORLD"};
//       WordCombo[] wordCombos = newWord.Setup(wordArray);
//       Assert.AreEqual("WORLD", wordCombos[0].FullWord);
//       Assert.AreEqual("W_R_D", wordCombos[0].IncompleteWord);
//       Assert.AreEqual("OL", wordCombos[0].MissingLetters);
//     }

//   [Test] COMMENTED OUT AS IT NEEDS TO BE MOCKED
//   public void GameBuilder_PassArrayOfTwoWords_Return_CorrectItems()
//     {
//       GameBuilder newWord = new GameBuilder();
//       string[] wordArray = {"WORLD", "SETUP"};
//       WordCombo[] wordCombos = newWord.Setup(wordArray);
//       Assert.AreEqual("WORLD", wordCombos[0].FullWord);
//       Assert.AreEqual("W_R_D", wordCombos[0].IncompleteWord);
//       Assert.AreEqual("OL", wordCombos[0].MissingLetters);
//       Assert.AreEqual("SETUP", wordCombos[1].FullWord);
//       Assert.AreEqual("S_T_P", wordCombos[1].IncompleteWord);
//       Assert.AreEqual("EU ", wordCombos[1].MissingLetters);
//     }
// }