namespace Royal.Pages
{
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
            if(CardName.Contains(" ")){
                CardName = CardName.Replace(" ", "+");
            }
            return map.Card(CardName);
        }

        public CardsPage Goto()
        {
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