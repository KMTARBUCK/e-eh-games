using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LetterMatch.Tests;
//hello?
public class LandingPageTest
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
    public void HomeIndex_ViewGreeting()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112"); //investigate how we would actually find this?!
        IWebElement greeting = driver.FindElement(By.Id("greeting"));
        Assert.AreEqual("Welcome", greeting.GetAttribute("innerHTML"));
    }

     [Test]
    public void HomeIndex_ClickPlayGame_RedirectsToGameIndex()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112"); 
        IWebElement playButton = driver.FindElement(By.Id("playgame"));
        playButton.Click();
        string currentUrl = driver.Url;
        Assert.AreEqual("http://127.0.0.1:5112/game", currentUrl);
    }
}