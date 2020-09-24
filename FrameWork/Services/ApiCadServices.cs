using System.Collections.Generic;
using System.Linq;
using FrameWork.Modles;
using Newtonsoft.Json;
using RestSharp;

namespace FrameWork.Services
{
    public class ApiCardService : ICardService
    {
        public const string CARDS_API= "https://statsroyale.com/api/cards";
        public IList<Card> GetAllCards()
        {
            var client = new RestClient(CARDS_API);
            var request = new RestRequest
            {
                Method= Method.GET,
                RequestFormat = DataFormat.Json
            };
            var response = client.Execute(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception("/cards endpoint failed with "+ response.StatusCode);
            }
            return JsonConvert.DeserializeObject<IList<Card>>(response.Content);
        }

        public Card GetCardByName(string CardName)
        {
            var cards = GetAllCards();
            return cards.FirstOrDefault(Card => Card.Name == CardName);
        }
    }
}