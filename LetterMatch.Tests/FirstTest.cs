using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LetterMatch.Tests;

public class FirstTest
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
    public void Test1()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112"); //investigate how we would actually find this?!
        IWebElement greeting = driver.FindElement(By.Id("greeting"));
        Assert.AreEqual("Welcome", greeting.GetAttribute("innerHTML"));
    }
}