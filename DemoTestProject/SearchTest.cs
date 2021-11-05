using System;
using DemoTestProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoTestProject
{
    public class SearchTest : DriverHelper
    {
        public static string Url = "https://demo23.opencart.pro/";
        [SetUp]
        public void Setup()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("--headless");
            Driver = new ChromeDriver(option);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);
        }

        [Test]
        [TestCase("iPhone")]
        public void Test1(string searchWord)
        {
            var basePageObject = new BasePageObject(Driver);
            Assert.AreEqual(basePageObject.IsElementDisplayed(_inputSearch), true,"Input search is not displayed");
            basePageObject.SetValue(_inputSearch, searchWord);
            basePageObject.ClickElement(_searchBtn);
            System.Threading.Thread.Sleep(5000);
        }

        [OneTimeTearDown]
        public void AfterAllMethods() => Driver.Quit();

        private readonly By _inputSearch = By.XPath("//input[@name='search']");
        private readonly By _searchBtn = By.CssSelector("#search button");
    }
}