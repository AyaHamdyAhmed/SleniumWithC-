namespace Royal.Pages
{
    using System.Linq;
    using FrameWork;
    using FrameWork.Modles;
    using FrameWork.Selenium;
    using OpenQA.Selenium;
    public class CardDetailsPage: PageBase
    {
        public readonly CardDetailsPageMap map;
        public CardDetailsPage()
        {
          map = new CardDetailsPageMap();
        }

        public (string category, string arena) GetCartCategory()
        {
            FW.log.Step("Get Card Category");
            var Categories= map.CardCatgory.Text.Split(',');
            return (Categories[0].Trim(), Categories[1].Trim());
        }

        public Card GetBaseCard()
        {
            FW.log.Step("Get Card Category");
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
        public IWebElement CardName => Driver.FindElement(By.CssSelector("[class*='cardName']"));
        public IWebElement CardCatgory => Driver.FindElement(By.CssSelector("[.card__rarity]"));
        public IWebElement CardRarity => Driver.FindElement(By.CssSelector("[class*='rarityCaption']"));
    }

}