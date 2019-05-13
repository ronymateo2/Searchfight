using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Searchfight {
    class BingCustomSearchStrategy : ISearchStrategy {
        private const string EndPointFormat =
            "https://api.cognitive.microsoft.com/bingcustomsearch/v7.0/search?q={1}&customconfig={0}&mkt=en-US";
        private const string BingKey = "47e9fd6d-c31a-4a8a-9b2a-78d1e04ec7a2";
        private const string SubscriptionKey = "6269b175c8264b488eb7523dd0e68bbb";

        public long GetResultNumbers(string query) {
            return this.GetResultNumbersAsync(query).Result;
        }
        private async Task<Int64> GetResultNumbersAsync(string query) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
            // sleep for 1 sec because it looks like bing is detected something wrong
            Thread.Sleep(1000);

            HttpResponseMessage response =
                await client.GetAsync(string.Format(EndPointFormat, BingKey, query));

            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(content);
                return jObject["webPages"]["totalEstimatedMatches"].Value<Int64>();
            }
            return 0L;
        }
    }
}
