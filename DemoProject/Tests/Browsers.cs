using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using DemoProject.Utils;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace RvCrashCourse2021
{
    [AllureNUnit]
    [TestFixture]
    [AllureSubSuite("AllureReportTypeSamples")]
    [AllureLink("https://github.com/unickq/allure-nunit")]
    class Browsers
    {

        [Test(Description = "Firefox1")]
        [AllureTag("TC-1")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureTms("TMS-12")]
        [AllureOwner("unickq")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        [AllureSubSuite("Simple")]
        public void Firefox1()
        {
            ApplicationSource applicationSource = new ApplicationSource(
                ApplicationSourceRepository.CHROME_TEMPORARY_WITHOUT_UI,
                10L, 10L);
            BrowserWrap driver = new BrowserWrap(applicationSource);
            //IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            //
            driver.ImplicitWaitSeconds(10);
            driver.OpenUrl("https://www.google.com.ua/");
            //
            driver.FindElementByClassName(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
