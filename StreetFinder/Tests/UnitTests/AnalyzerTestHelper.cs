using System;
using System.Collections.Generic;
using System.IO;
using Lucene.Net.Analysis;

namespace Tests.UnitTests
{   
    public class AnalyzerTestHelper
    {

        public static IEnumerable<string> TokensFromAnalysis(Analyzer analyzer, String text)
        {
            var stream = analyzer.TokenStream("contents", new StringReader(text));

            var termAttr = stream.GetAttribute<Lucene.Net.Analysis.Tokenattributes.ITermAttribute>();

            while(stream.IncrementToken())
            {
                var term = termAttr.Term;

                yield return term;
            }
        }

        public static void DisplayTokens(Analyzer analyzer, String text)
        {
            var results = TokensFromAnalysis(analyzer, text);

            foreach (var result in results)
            {
             
                Console.WriteLine(result);   
            }
        }
    }
}