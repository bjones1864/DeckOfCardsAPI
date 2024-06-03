using Microsoft.AspNetCore.DataProtection;
using System.Net;
using Newtonsoft.Json;

namespace DeckOfCardsAPI.Models
{
    public class DrawCardsDAL
    {
        public static DrawCards GetCards(string deck) //Adjust
        {
            //adjust
            //setup
            string url = $"https://deckofcardsapi.com/api/deck/{deck}/draw/?count=5";
            //NEED TO HIDE API KEY
            //use .gitignore and add class to be hidden

            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //adjust
            //Convert to c#
            //Install Newtonsoft.json
            DrawCards result = JsonConvert.DeserializeObject<DrawCards>(JSON);
            return result;
        }

        public static string GetNewDeck()
        {
            string url = $"https://deckofcardsapi.com/api/deck/new/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            string result = JsonConvert.DeserializeObject<NewDeck>(JSON).deck_id;
            return result;

        }

        public static string ShuffleDeck(string deck)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deck}/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            string result = JsonConvert.DeserializeObject<NewDeck>(JSON).deck_id;
            return result;
        }
    }
}
