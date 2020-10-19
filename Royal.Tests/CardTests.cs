using System.IO;
using FrameWork.Modles;
using FrameWork.Services;
using NUnit.Framework;
using Royal.Pages;
using System.Collections.Generic;
using Tests.Base;

namespace Tests
{
    public class CardTests : TestBase
    {

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_Is_On_Cards_Page(Card card)
        {
            var cardOnPage= Pages.cards.Goto().GetCardByName(card.Name);
            Assert.That(cardOnPage.Displayed,"IceSpirit card isn't displayed");
        }

        [Test]
        public void IceSpirirt_HeadersAreDisplayed_On_CardsDetails_Page()
        {
            Pages.cards.Goto().GetCardByName("Ice Spirit").Click();
            var CardDetails = new CardDetailsPage();
            var (Category, arena) = CardDetails.GetCartCategory();
            var cardName= CardDetails.map.CardName.Text;
            var cardRarity= CardDetails.map.CardRarity.Text.Split('\n')[1];
            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", Category);
            Assert.AreEqual("Arena 8", arena);
            Assert.AreEqual("Common", cardRarity);

        }

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_HeadersAreCorrect_On_CardsDetails_Page(Card card)
        {
            Pages.cards.Goto().GetCardByName(card.Name).Click();
            var cardOnThePage= Pages.cardDetails.GetBaseCard();
            Assert.AreEqual(card.Name, cardOnThePage.Name);
            Assert.AreEqual(card.Type, cardOnThePage.Type);
            Assert.AreEqual(card.Arena, cardOnThePage.Arena);
            Assert.AreEqual(card.Rarity, cardOnThePage.Rarity);
       }

       static IList<Card> apiCards = new ApiCardService().GetAllCards();

    }
}