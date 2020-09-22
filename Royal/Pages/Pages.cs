using System;
namespace Royal.Pages
{
    public class Pages
    {
        [ThreadStatic]
        public static CardsPage cards;

        [ThreadStatic]
        public static CardDetailsPage cardDetails;
        
        public static void Init()
        {
            cards = new CardsPage();
            cardDetails = new CardDetailsPage();
        }

    }
}