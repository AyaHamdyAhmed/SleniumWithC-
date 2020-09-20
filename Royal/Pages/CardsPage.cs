namespace Royal.Pages
{
    using OpenQA.Selenium;
    public class CardsOnPage : PageBase
    {
        public readonly CardsPageMap map;
        public CardsOnPage(IWebDriver driver): base(driver)
        {
            map= new CardsPageMap(driver);
        }
        public IWebElement GetCardByName(string CardName)
        {
            if(CardName.Contains(" ")){
                CardName = CardName.Replace(" ", "+");
            }
            return map.Card(CardName);
        }

        public CardsOnPage Goto()
        {
            headerNav.GoToCardsPage();
            return this;
        }
    }

    public class CardsPageMap
    {
        IWebDriver _driver;
        public CardsPageMap(IWebDriver driver){
            _driver= driver;
        }
        public IWebElement IceSpirit => _driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));

        public IWebElement Card(string name) => _driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}