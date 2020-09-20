namespace Royal.Pages
{
    using OpenQA.Selenium;
    public abstract class PageBase
    {
        public readonly HeaderNav headerNav;
        public PageBase(IWebDriver driver)
        {
            headerNav = new HeaderNav(driver);
        }
    }
}
    