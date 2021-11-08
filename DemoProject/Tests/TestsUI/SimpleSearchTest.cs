using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Allure.Commons;
using DemoProject.Utils;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace RvCrashCourse2021
{
    [AllureNUnit]
    [TestFixture]
    [AllureSubSuite("Simple SearchTest")]
    [AllureLink("https://github.com/unickq/allure-nunit")]
    class SimpleSearchTest
    {

        [Test(Description = "Search defaults")]
        [AllureTag("TC-1")]
        [AllureOwner("Leonid M")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Simple")]
        public void SearchDefault()
        {
            ApplicationSource applicationSource = new ApplicationSource(ApplicationSourceRepository.CHROME_TEMPORARY_WITHOUT_UI, 10L, 10L);
            BrowserWrap driver = new BrowserWrap(applicationSource);
            driver.ImplicitWaitSeconds(10);
            driver.OpenUrl("https://demo.opencart.com/");
            Assert.AreEqual(driver.IsElementDisplayed(_inputSearch), true, "Input search is not displayed");
            Assert.AreEqual(driver.IsElementDisplayed(_searchBtn), true, "Search button is not displayed");
            Thread.Sleep(1000);
        }

        [Test(Description = "Search execute")]
        [AllureTag("TC-2")]
        [AllureOwner("Leonid M")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Simple")]
        public void SearchExecute()
        {
            ApplicationSource applicationSource = new ApplicationSource(ApplicationSourceRepository.CHROME_TEMPORARY_WITHOUT_UI, 10L, 10L);
            BrowserWrap driver = new BrowserWrap(applicationSource);
            driver.ImplicitWaitSeconds(10);
            driver.OpenUrl("https://demo.opencart.com/");
            driver.FindElementByClassName(_inputSearch).SendKeys("iPhone");
            driver.ClickElement(_searchBtn);
            Thread.Sleep(1000);
            Assert.AreEqual(driver.GetTextElement(_searchResult), "Search - iPhone", "Search result is not found");
            driver.Quit();
        }

        private readonly By _inputSearch = By.XPath("//input[@name='search']");
        private readonly By _searchBtn = By.CssSelector("#search button");
        private readonly By _searchResult = By.XPath("//div[@id='content']/h1");
    }
}
