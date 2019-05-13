using System;
using System.Collections.Generic;
using System.Text;

namespace Searchfight {
    public interface ISearchStrategy {
        Int64 GetResultNumbers(string query);
    }
}
