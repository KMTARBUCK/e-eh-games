namespace LetterMatch.Tests;
using LetterMatch.Models;

public class WordCheckerTest
{
    [Test]
    [TestCase("MAKERS", "MAKERS")]
    [TestCase("test", "test")]
    [TestCase("word", "word")]
    [TestCase("dictionary", "dictionary")]
    public void CheckTwoMatchingValues_ReturnTrueIfMatching(string word1, string word2)
    {
        Assert.AreEqual("correct", WordChecker.Check(word1, word2));
    }
    [Test]
    [TestCase("MAKERS", "MAKER")]
    [TestCase("test", "this")]
    [TestCase("word", "ward")]
    [TestCase("dictionary", "thesaurus")]
    public void CheckTwoMatchingValues_ReturnFalseIfNotMatching(string word1, string word2)
    {
        Assert.AreEqual("incorrect", WordChecker.Check(word1, word2));
    }
}