using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Common;

namespace DesignPatternsSampleApplication.Proxies
{
    // Abstract the asynchronous calls - takes the place of the API without actually doing it
    public class CardsProxy
    {
        private HttpClient _http;
        private IEnumerable<Card> _cards;

        public CardsProxy()
        {
            _http = new HttpClient();
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            if (_cards != null)
            {
                return _cards;
            }

            _cards = await FetchCards();
            return _cards;

        }

        // Makes the call here - could use a totally different implementation here
        private async Task<IEnumerable<Card>> FetchCards()
        {
            using (_http = new HttpClient())
            {
                var cardJson = await _http.GetStringAsync("http://localhost:5000/api/cards");
                return (JsonSerializer.Deserialize<IEnumerable<Card>>(cardJson) ?? Array.Empty<Card>()).ToArray();
            }
        }
    }
}