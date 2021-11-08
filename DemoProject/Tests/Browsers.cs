using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Firefox;
using NUnit.Allure.Core;

namespace RvCrashCourse2021
{
    [AllureNUnit]
    [TestFixture]
    [AllureSubSuite("AllureReportTypeSamples")]
    class Browsers
    {

        [Test(Description = "Firefox1")]
        [AllureTag("TC-1")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("unickq")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        [AllureSubSuite("Simple")]
        public void Firefox1()
        {
            IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        [Test]
        public void Firefox2()
        {
            FirefoxProfileManager profileManager = new FirefoxProfileManager();
            FirefoxProfile profile = profileManager.GetProfile("default");
            //IWebDriver driver = new FirefoxDriver(profile); // Deprecated
            //
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome1()
        {
            IWebDriver driver = new ChromeDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome2()
        {   // Default Profile
            ChromeOptions options = new ChromeOptions();
            string homePath = Environment.GetEnvironmentVariable("HOMEPATH");
            Console.WriteLine("homePath = " + homePath);
            string userProfile = homePath + "\\AppData\\Local\\Google\\Chrome\\User Data";
            //string userProfile = homePath + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default"; // ERROR
            Console.WriteLine("userProfile = " + userProfile);
            options.AddArguments("--user-data-dir=" + userProfile);
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            //driver.Quit();
        }

        //[Test]
        public void Chrome3()
        {   // Add Arguments
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            //options.AddArguments("--headless");
            IWebDriver driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

        //[Test]
        public void Chrome4()
        {   // Executable Location
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"C:\Users\yharasym\Downloads\VideoTAQC\ChromiumPortable\ChromiumPortable.exe";
            //options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            IWebDriver driver = new ChromeDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            driver.FindElement(By.Name("q")).SendKeys("Cheese");
            Thread.Sleep(1000);
            driver.Quit();
        }

       // [Test]
        public void Chrome5()
        {   // Headless
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            IWebDriver driver = new ChromeDriver(options);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            //
            Console.WriteLine("Title0= " + driver.Title);
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            Console.WriteLine("Title1= " + driver.Title);
            //driver.FindElement(By.Name("q")).SendKeys("Cheese");
            //driver.FindElement(By.Name("q")).Submit();
            //Thread.Sleep(2000);
            //
            //ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            //Screenshot screenshot = takesScreenshot.GetScreenshot();
            //screenshot.SaveAsFile("с:/ScreenshotGoogle1.png", ScreenshotImageFormat.Png);
            ////
            Console.WriteLine("Title2= " + driver.Title);
            driver.Quit();
        }

    }
}
