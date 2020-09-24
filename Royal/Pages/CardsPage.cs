namespace Royal.Pages
{
    using FrameWork;
    using FrameWork.Selenium;
    using OpenQA.Selenium;
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap map;
        public CardsPage()
        {
            map= new CardsPageMap();
        }
        public IWebElement GetCardByName(string CardName)
        {
            FW.log.Step("search for card by Name");
            if(CardName.Contains(" ")){
                CardName = CardName.Replace(" ", "+");
            }
            return map.Card(CardName);
        }

        public CardsPage Goto()
        {
            FW.log.Step("open cards page");
            headerNav.GoToCardsPage();
            return this;
        }
    }

    public class CardsPageMap
    {
        public IWebElement IceSpirit => Driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));

        public IWebElement Card(string name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}