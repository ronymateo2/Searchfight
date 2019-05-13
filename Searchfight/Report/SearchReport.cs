using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Searchfight {
    class Report {
        private readonly IRenderer renderer;
        public Report(IRenderer render) {
            this.renderer = render;
        }

        internal void Render(IEnumerable<SearchEngineResult> results) {
            var reportData = new ReportData {};

            reportData.keywordStatements = from r in results
                                    group r by r.Keyword into @group
                                    select new KeywordStatement {
                                        Keyword = new ReportKeyword(@group.Key),
                                        EngineResults = @group.Select(item =>
                                        Tuple.Create(new ReportEngineName(item.Engine), new ReportTotal(item.TotalResults)))
                                    };

            reportData.WinnersByEngine = from r in results
                          group r by r.Keyword into @group
                          select Tuple.Create(
                              new ReportEngineName(@group.Aggregate(getMaxTotal()).Engine),
                              new ReportKeyword(@group.Key)
                             );

            reportData.Winner = (from r in results
                               group r by r.Keyword into @group
                               select new {
                                   Keyword = new ReportWinner(@group.Key),
                                   Total = @group.Select(t => t.TotalResults).Aggregate((a, b) => a + b)
                               }).Aggregate((aTw, bTw) => {
                                   if (aTw.Total > bTw.Total)
                                       return aTw;
                                   else
                                       return bTw;
                               }).Keyword;

            this.renderer.Render(reportData);
        }

        private static Func<SearchEngineResult, SearchEngineResult, SearchEngineResult> getMaxTotal() {
            return (a, b) => {
                if (a.TotalResults > b.TotalResults)
                    return a;
                return b;
            };
        }
    }
}

