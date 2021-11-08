using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Utils
{
    class ApplicationSourceRepository
    {
        public const string FIREFOX_TEMPORARY_WHITH_UI = "FirefoxTemporaryWhithUI";
        public const string CHROME_TEMPORARY_WHITH_UI = "ChromeTemporaryWhithUI";
        public const string CHROME_TEMPORARY_MAXIMIZED_WHITH_UI = "ChromeTemporaryMaximizedWhithUI";
        public const string CHROME_TEMPORARY_WITHOUT_UI = "ChromeTemporaryWithoutUI";
        public const string SELENOID_CHROME = "SelenoidChrome";
        public const string SELENOID_FIREFOX = "SelenoidFirefox";


        private ApplicationSourceRepository() { }

        public static ApplicationSource Default()
        {
            return ChromeTemporaryUI();
        }

        public static ApplicationSource FirefoxTemporaryUI()
        {
            return new ApplicationSource(FIREFOX_TEMPORARY_WHITH_UI, 10L, 10L);
        }

        public static ApplicationSource ChromeTemporaryUI()
        {
            return new ApplicationSource(CHROME_TEMPORARY_WHITH_UI, 10L, 10L);
        }

        public static ApplicationSource ChromeMaximizedUI()
        {
            return new ApplicationSource(CHROME_TEMPORARY_MAXIMIZED_WHITH_UI, 10L, 10L);
        }

        public static ApplicationSource ChromeWithoutUI()
        {
            return new ApplicationSource(CHROME_TEMPORARY_WITHOUT_UI, 10L, 10L);
        }

        public static ApplicationSource SelenoidChrome()
        {
            return new ApplicationSource(SELENOID_CHROME, 10L, 10L);
        }
    }
}
