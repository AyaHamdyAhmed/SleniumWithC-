using FrameWork.Modles;

namespace FrameWork.Services
{
    public class InMemoryCardService : ICardService
    {
        public Card GetCardByName(string CardName)
        {
            switch (CardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();
                case "Mirror":
                    return new MirorrCard();
                default:
                throw new System.ArgumentException("Card is not avaliable: "+ CardName);
            }
        }
    }
}