using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using DemoProject.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace CrashCourse2021
{
    [AllureNUnit]
    [TestFixture]
    [AllureSubSuite("Simple SearchTest")]
    class SimpleSearchTest
    {
        private readonly string _url = "https://demo.opencart.com/";
        [Test(Description = "Search defaults")]
        [AllureTag("TC-1")]
        [AllureOwner("Leonid M")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Simple")]
        public void SearchDefault()
        {
            ApplicationSource aplicationsSpurce = new ApplicationSource(ApplicationSourceRepository.CHROME_TEMPORARY_WITHOUT_UI, 10L, 10L);
            //ApplicationSource aplicationsSpurce = new ApplicationSource(ApplicationSourceRepository.CHROME_TEMPORARY_WHITH_UI, 10L, 10L);
            BrowserWrap _driver = new BrowserWrap(aplicationsSpurce);
            _driver.OpenUrl(_url);
            Assert.AreEqual(_driver.IsElementDisplayed(_searchInput), true, "Input search is not displayed");
            Assert.AreEqual(_driver.IsElementDisplayed(_searchBtn), true, "Search button is not displayed");
            //Thread.Sleep(1000);
            _driver.Quit();
        }

        [Test(Description = "Search execute")]
        [AllureTag("TC-2")]
        [AllureOwner("Leonid M")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Simple")]
        public void SearchExecute()
        {
            ApplicationSource aplicationsSpurce = new ApplicationSource(ApplicationSourceRepository.CHROME_TEMPORARY_WITHOUT_UI, 10L, 10L);
            //ApplicationSource aplicationsSpurce = new ApplicationSource(ApplicationSourceRepository.CHROME_TEMPORARY_WHITH_UI, 10L, 10L);
            BrowserWrap _driver = new BrowserWrap(aplicationsSpurce);
            _driver.OpenUrl(_url);
            _driver.FindElementByClassName(_searchInput).SendKeys("iPhone");
            _driver.ClickElement(_searchBtn);
            //Thread.Sleep(1000);
            Assert.AreEqual(_driver.GetTextElement(_searchResult), "Search - iPhone", "Search result is not found");
            _driver.Quit();
        }

        private readonly By _searchInput = By.XPath("//input[@name='search']");
        private readonly By _searchBtn = By.CssSelector("#search button");
        private readonly By _searchResult = By.XPath("//div[@id='content']/h1");
    }
}
