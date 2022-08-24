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
    public void HomeIndex_ClickPlayGame_RedirectsToGameIndex()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112"); 
        IWebElement playButton = driver.FindElement(By.Id("playgame"));
        playButton.Click();
        string currentUrl = driver.Url;
        Assert.AreEqual("http://127.0.0.1:5112/game", currentUrl);
    }

    [Test]
    public void HomeIndex_InputName_DisplaysNameOnGamePage()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112"); 
        IWebElement nameField = driver.FindElement(By.Id("username"));
        nameField.SendKeys("Bruce"); 
        IWebElement submitButton = driver.FindElement(By.Id("submit"));
        submitButton.Click();
        IWebElement gameGreeting = driver.FindElement(By.Id("greeting"));
        string userGreeting = gameGreeting.GetAttribute("innerHTML");
        Assert.That(userGreeting, Does.Contain("Bruce"));
    }
}