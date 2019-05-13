using System;
using System.Collections.Generic;

namespace Searchfight {
    class KeywordStatement {
        public ReportKeyword Keyword { get; set; }
        public IEnumerable<Tuple<ReportEngineName, ReportTotal>> EngineResults { get; set; }
    }
}