using FrameWork.Modles;

namespace FrameWork.Services
{
    public interface ICardService
    {
        Card GetCardByName(string CardName);
        
    }
}