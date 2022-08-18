using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LetterMatch.Tests;

public class GameIndexTest
{
    ChromeDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [TearDown]
    public void TearDown() {
      driver.Quit();
    }

    [Test]
    public void GameIndex_ClickPlay_RedirectsToGameIndex()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); 
        IWebElement playButton = driver.FindElement(By.Id("play"));
        playButton.Click();
        string currentUrl = driver.Url;
        Assert.AreEqual("http://127.0.0.1:5112/game", currentUrl);
    }

    [Test]
    public void GameIndex_ClickTwoButtons_DeselectsFirst()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); 
        ICollection<IWebElement> incompleteWords = driver.FindElements(By.ClassName("incompleteWord"));
        IWebElement firstIncompleteWord = incompleteWords.First();
        IWebElement lastIncompleteWord = incompleteWords.Last();
        firstIncompleteWord.Click();
        lastIncompleteWord.Click();
        Assert.IsFalse(firstIncompleteWord.Selected);
    }

    [Test]
    public void GameIndex_ClickTwoButtons_BothSelected()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); 
        ICollection<IWebElement> incompleteWords = driver.FindElements(By.ClassName("incompleteWord"));
        IWebElement firstIncompleteWord = incompleteWords.First();
        ICollection<IWebElement> missingLetters = driver.FindElements(By.ClassName("missingLetters"));
        IWebElement firstMissingLetter = missingLetters.First();
        firstIncompleteWord.Click();
        firstMissingLetter.Click();
        Assert.IsTrue(firstIncompleteWord.Selected);
        Assert.IsTrue(firstMissingLetter.Selected);
        // IWebElement playButton = driver.FindElement(By.Id("play"));
        // playButton.Click();
        // string currentUrl = driver.Url;
        // Assert.AreEqual("http://127.0.0.1:5112/game", currentUrl);
    }

}