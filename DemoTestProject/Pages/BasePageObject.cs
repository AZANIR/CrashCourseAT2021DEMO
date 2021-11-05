using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DemoTestProject.Pages
{
    class BasePageObject
    {
        private readonly IWebDriver _webDriver;

        public BasePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public bool IsElementDisplayed(By selector)
        {
            return _webDriver.FindElement(selector).Displayed;
        }
        public void ClickElement(By selector)
        {
            _webDriver.FindElement(selector).Click();
            System.Threading.Thread.Sleep(1000);
        }
        public void SetValue(By selector, string text)
        {
            _webDriver.FindElement(selector).SendKeys(text);
        }
    }
}
