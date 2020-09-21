using System;
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
            _driver= new ChromeDriver(Path.GetFullPath(@"../../../../"+ "_drivers"));
        }

        public static IWebDriver current => _driver ?? throw new NullReferenceException("_driver is null");
    }
}