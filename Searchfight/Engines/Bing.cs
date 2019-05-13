using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight {
    public class Bing : ISearchEngine {
        private readonly ISearchStrategy searchStrategy;
        public string Name => "Bing";

        public Bing(ISearchStrategy searchStrategy) {
            this.searchStrategy = searchStrategy;
        }

        public SearchEngineResult Search(string query) {
            return new SearchEngineResult(
                query,
                this.searchStrategy.GetResultNumbers(query),
                this.Name);
        }
    }
}
