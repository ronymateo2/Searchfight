using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Searchfight {
    public class Google : ISearchEngine {
        private readonly ISearchStrategy searchStrategy;
        public string Name => "Google";

        public Google(ISearchStrategy searchStrategy) {
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

