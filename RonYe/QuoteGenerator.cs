using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace RonYe
{
    public class QuoteGenerator
    {
        public static HttpClient client = new HttpClient();

        public QuoteGenerator()
        {
        }

        public static string KanyeQuote()
        {
            var kanyeUrl = "https://api.kanye.rest";
            var kanyeResponse = client.GetStringAsync(kanyeUrl).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return Char.IsLetter(kanyeQuote[kanyeQuote.Length - 1]) ? $"Kanye: \"{kanyeQuote}.\"" :
                                                                      $"Kanye: \"{kanyeQuote}\"";
        }

        public static string RonQuote()
        {
            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronUrl).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace("[", "").Replace("]", "").Trim();
            return $"Ron: {ronQuote}";
        }

    }

        
}
