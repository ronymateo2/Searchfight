using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight {
    public interface ISearchEngine {
        SearchEngineResult Search(string query);
    }
}
