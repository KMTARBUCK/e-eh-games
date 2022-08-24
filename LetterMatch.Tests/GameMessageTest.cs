namespace LetterMatch.Tests;
using LetterMatch.Models; 
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;   

public class GameMessageTest
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
    public void GameIndex_ClickMatchingPair_RedirectToCorrectResultPage()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112"); 
        IWebElement nameField = driver.FindElement(By.Id("username"));
        nameField.SendKeys("Bruce"); 
        IWebElement submitButton = driver.FindElement(By.Id("submit"));
        submitButton.Click();
        // IWebElement gameGreeting = driver.FindElement(By.Id("greeting"));
      //   string userGreeting = gameGreeting.GetAttribute("innerHTML");
      //   Assert.That(userGreeting, Does.Contain("Bruce"));
      // // // [Test]
      // // public void GameIndex_ClickMatchingPair_RedirectToCorrectResultPage()
      //   driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); 
        IWebElement incompleteWord = driver.FindElement(By.Name("incompleteWord"));
        IWebElement missingLetter = driver.FindElement(By.Name("missingLetters"));
        incompleteWord.Click();
        missingLetter.Click();
        IWebElement playButton = driver.FindElement(By.Id("play"));
        playButton.Click();
        string currentUrl = driver.Url;
        Assert.AreEqual("http://127.0.0.1:5112/game?result=correct", currentUrl);
        IWebElement resultMessage = driver.FindElement(By.Id("message"));
        string resultMessageContent = resultMessage.GetAttribute("innerHTML");
        Assert.That(resultMessageContent, Does.Contain("Well done!"));
    }
}