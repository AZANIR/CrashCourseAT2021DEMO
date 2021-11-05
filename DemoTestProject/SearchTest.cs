using System;
using DemoTestProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoTestProject
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class Tests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private readonly IWebDriver _driver = new TWebDriver();
        public string Url = "https://demo23.opencart.pro/";

        [OneTimeSetUp]
        public void BeforeAllMethods() => _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Url);
        }

        [Test]
        [TestCase("iPhone")]
        public void Test1(string searchWord)
        {
            var basePageObject = new BasePageObject(_driver);
            Assert.AreEqual(basePageObject.IsElementDisplayed(_inputSearch), true,"Input search is not displayed");
            basePageObject.SetValue(_inputSearch, searchWord);
            basePageObject.ClickElement(_searchBtn);
            System.Threading.Thread.Sleep(5000);
        }

        [OneTimeTearDown]
        public void AfterAllMethods() => _driver.Quit();

        private readonly By _inputSearch = By.XPath("//input[@name='search']");
        private readonly By _searchBtn = By.CssSelector("#search button");
    }
}