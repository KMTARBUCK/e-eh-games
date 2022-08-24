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
        Assert.AreEqual("http://127.0.0.1:5112/game?result=missing", currentUrl);
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
    }

    // MATCHING WORDS
    // Navigate to Game index
    // Find elements by class -> ICollection
    // Find elements by label 'for='happy'' or by innerHtml -> IWebElement
    // Click each button
    // Find play button -> IWebElement
    // Click play button
    // Assert that currenturl == http://127.0.0.1:5112/game?result=correct

    [Test]
    public void GameIndex_ClickMatchingPair_RedirectToCorrectResultPage()
    {
        driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); 
        IWebElement incompleteWord = driver.FindElement(By.Name("incompleteWord"));
        IWebElement missingLetter = driver.FindElement(By.Name("missingLetters"));
        incompleteWord.Click();
        missingLetter.Click();
        IWebElement playButton = driver.FindElement(By.Id("play"));
        playButton.Click();
        string currentUrl = driver.Url;
        Assert.AreEqual("http://127.0.0.1:5112/game?result=correct", currentUrl);
    }

     // NON-MATCHING WORDS
    // Navigate to Game index
    // Find elements by class -> ICollection
    // Find elements by label 'for='happy'' or by innerHtml -> IWebElement
    // Click each button
    // Find play button -> IWebElement
    // Click play button
    // Assert that currenturl == http://127.0.0.1:5112/game?result=incorrect

    // [Test] COMMENTED OUT AS IT NEEDS TO BE MOCKED
    //     public void GameIndex_ClickUnmatchingPair_RedirectToIncorrectResultPage()
    //     {
    //         driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); 
    //         IWebElement incompleteWord = driver.FindElement(By.Id("radio1"));
    //         IWebElement missingLetter = driver.FindElement(By.Id("radio4"));
    //         incompleteWord.Click();
    //         missingLetter.Click();
    //         IWebElement playButton = driver.FindElement(By.Id("play"));
    //         playButton.Click();
    //         string currentUrl = driver.Url;
    //         Assert.AreEqual("http://127.0.0.1:5112/game?result=incorrect", currentUrl);
        // }

    
    // [Test] COMMENTED OUT AS IT NEEDS TO BE MOCKED
    // public void GameIndex_NavigateToButtons_ReturnCorrectHtml()
    // {
    //     driver.Navigate().GoToUrl("http://127.0.0.1:5112/game"); 
    //     IWebElement incompleteWord = driver.FindElement(By.ClassName("incompleteWord"));
    //     IWebElement missingLetter = driver.FindElement(By.ClassName("missingLetters"));
    //     string incompleteWordValue = incompleteWord.GetAttribute("innerHTML");
    //     string missingLetterValue = missingLetter.GetAttribute("innerHTML");
    //     Assert.That(incompleteWordValue, Does.Contain("H_L_O"));
    //     Assert.That(missingLetterValue, Does.Contain("EL"));
    // }



    // POPULATING BUTTONS 
    // Navigate to Game index
    // ViewBag.WordCombo = new WordCombo()
    // Find elements by class -> ICollection
    // Find elements by label 'for='happy'' or by innerHtml -> IWebElement
    // Click each button
    // Find play button -> IWebElement
    // Click play button
    // Assert that currenturl == http://127.0.0.1:5112/game?result=incorrect

    // MAYBE (PROBABLY NOT)
    // Create hidden form in home index play button to parse a word into
    // Use that word in the WordSplitter method
    // Game view displays split word and missing letters as buttons
    // Those buttons match when pressing play game button
}