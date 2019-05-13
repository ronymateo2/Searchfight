using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Searchfight {
    class ConsoleRenderer : IRenderer {
        public void Render(ReportData reportData) {
            reportData.keywordStatements.ToList().ForEach(ks => {
                var results = string.Join(" ", ks.EngineResults.Select(r => string.Format("{0}: {1}", r.Item1, r.Item2)));
                Console.WriteLine(string.Format("{0} {1}", ks.Keyword, results));
            });

            reportData.WinnersByEngine.ToList().ForEach(w => {
                Console.WriteLine(string.Format("{0} winner: {1}", w.Item1, w.Item2));
            });

            Console.WriteLine(string.Format("Total winner: {0}", reportData.Winner));
        }
    }

    /// <summary>
    /// ReportData, strongly type Fields everything has to be typed for reporting 
    /// for example ReportKeyword is strongly type the value string is just the implementation
    /// </summary>
    class ReportData {
        public IEnumerable<KeywordStatement> keywordStatements { get; set; }
        public IEnumerable<Tuple<ReportEngineName, ReportKeyword>> WinnersByEngine { get; set; }
        public ReportWinner Winner { get; set; }
    }
}