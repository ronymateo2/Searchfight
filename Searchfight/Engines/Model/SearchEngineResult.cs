using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight {
    public class SearchEngineResult {
        public string Keyword { get; }

        public long TotalResults { get; }

        public string Engine { get; }

        public SearchEngineResult(string keyword, long totalResults, string engine) {
            Keyword = keyword;
            TotalResults = totalResults;
            Engine = engine;
        }
    }
}
