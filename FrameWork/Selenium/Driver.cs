using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace FrameWork.Selenium
{
    public static class Driver{
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void InitDriver()
        {
            FW.log.Info("Browser: Chrome");
            _driver= new ChromeDriver(Path.GetFullPath(@"../../../../"+ "_drivers"));
        }

        public static IWebDriver current => _driver ?? throw new NullReferenceException("_driver is null");

        public static void GoTO(string url)
        {
            if(!url.StartsWith("http"))
            {
              url= $"http://{url}";
            }
            FW.log.Info(url);
            current.Navigate().GoToUrl(url);
        }
        public static void Quit()
        {
            FW.log.Info("Close Browser");
            current.Quit();
            current.Dispose();
        }
        public static IWebElement FindElement(By by)
        {
            return current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return current.FindElements(by);
        }
    }
}