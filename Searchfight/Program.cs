using System;
using System.Collections.Generic;
using System.Linq;

namespace Searchfight {
    class Program {
        static void Main(string[] args) {
            var keywordList = args.ToList();

            if(keywordList.Count == 0) {
                Console.WriteLine("Please enter something to search");
                Console.ReadLine();
                return;
            }

            // Posibility to change the strategy to search scraper
            // this implementation is based on custom search api
            var google = new Google(new GoogleCustomSearchStrategy());
            var bing = new Bing(new BingCustomSearchStrategy());

            var engines = new List<ISearchEngine> { google, bing };
            var results = engines.SelectMany(engine => keywordList.Select(keyword => engine.Search(keyword))).ToList();
            // Posibility change the  implementation to html version plain text or json format
            // this implementation is a console format
            var render = new ConsoleRenderer();
            var report = new Report(render);
            report.Render(results);
            Console.ReadLine();
        }
    }
}
