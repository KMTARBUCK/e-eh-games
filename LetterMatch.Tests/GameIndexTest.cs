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
        driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); //investigate how we would actually find this?!
        IWebElement playButton = driver.FindElement(By.Id("play"));
        playButton.Click();
        string currentUrl = driver.Url;
        Assert.AreEqual("http://127.0.0.1:5112/game", currentUrl);
    }
}