namespace Royal.Pages
{
    using System.Linq;
    using FrameWork.Modles;
    using OpenQA.Selenium;
    public class CardDetailsPage: PageBase
    {
        public readonly CardDetailsPageMap map;
        public CardDetailsPage(IWebDriver driver):base(driver)
        {
          map = new CardDetailsPageMap(driver);
        }

        public (string category, string arena) GetCartCategory()
        {
            var Categories= map.CardCatgory.Text.Split(',');
            return (Categories[0].Trim(), Categories[1].Trim());
        }

        public Card GetBaseCard()
        {
            var (Category, arena) = GetCartCategory();
            return new Card
            {
                Name = map.CardName.Text,
                Rarity= map.CardRarity.Text.Split('\n').Last(),
                Type = Category,
                Arena = arena
            };
        }
    }

    public class CardDetailsPageMap
    {
        IWebDriver _driver;
        public CardDetailsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public IWebElement CardName => _driver.FindElement(By.CssSelector("[class*='cardName']"));
        public IWebElement CardCatgory => _driver.FindElement(By.CssSelector("[.card__rarity]"));
        public IWebElement CardRarity => _driver.FindElement(By.CssSelector("[class*='rarityCaption']"));
    }

}