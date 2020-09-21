using System.IO;
using FrameWork.Modles;
using FrameWork.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using FrameWork.Selenium;
using Royal.Pages;
namespace Tests
{
    public class CardTests
    {

        [SetUp]
        public void BeforeTest()
        {
            Driver.InitDriver();
            Driver.current.Url= "https://statsroyale.com";
        }

        [Test]
        public void IceSpirirt_Is_On_Cards_Page()
        {
            var CardsPage= new CardsOnPage(Driver.current);
            var IceSpirit= CardsPage.Goto().GetCardByName("Ice Spirit");
            Assert.That(IceSpirit.Displayed,"IceSpirit card isn't displayed");
        }

        [Test]
        public void IceSpirirt_HeadersAreDisplayed_On_CardsDetails_Page()
        {
            new CardsOnPage(Driver.current).Goto().GetCardByName("Ice Spirit").Click();
            var CardDetails = new CardDetailsPage(Driver.current);
            var (Category, arena) = CardDetails.GetCartCategory();
            var cardName= CardDetails.map.CardName.Text;
            var cardRarity= CardDetails.map.CardRarity.Text.Split('\n')[1];
            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", Category);
            Assert.AreEqual("Arena 8", arena);
            Assert.AreEqual("Common", cardRarity);

        }
        static string[] cardNames={"Ice Spirit", "Mirror"};
        [Test, Category("cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_HeadersAreCorrect_On_CardsDetails_Page(string cardName)
        {
            new CardsOnPage(Driver.current).Goto().GetCardByName(cardName).Click();
            var CardDetails = new CardDetailsPage(Driver.current);
            var cardOnThePage= CardDetails.GetBaseCard();
            var Card = new InMemoryCardService().GetCardByName(cardName);
            Assert.AreEqual(Card.Name, cardOnThePage.Name);
            Assert.AreEqual(Card.Type, cardOnThePage.Type);
            Assert.AreEqual(Card.Arena, cardOnThePage.Arena);
            Assert.AreEqual(Card.Rarity, cardOnThePage.Rarity);

        }

        [TearDown]
        public void AfterTest()
        {
          Driver.current.Quit();
        }


    }
}