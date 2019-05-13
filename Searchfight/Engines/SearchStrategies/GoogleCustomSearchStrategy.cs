using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight {
    class GoogleCustomSearchStrategy : ISearchStrategy {
        private const string GoogleKey = "AIzaSyBeI7ddhIJuT0KauMvFyfXK6gKVsCPZ_5c";
        private const string EnpointFormat = "https://www.googleapis.com/customsearch/v1?key={0}&cx={1}&q={2}";
        private const string SearcEngineID = "014084283956793036831:-b0g7eebpa0";

        public long GetResultNumbers(string query) {
            return this.GetResultNumbersAsync(query).Result;
        }
        private async Task<Int64> GetResultNumbersAsync(string query) {
            HttpClient client = new HttpClient();
            HttpResponseMessage response =
                await client.GetAsync(string.Format(EnpointFormat, GoogleKey, SearcEngineID, query));

            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(content);
                return jObject["searchInformation"]["totalResults"].Value<Int64>();
            }
            return 0L;
        }

    }
}
