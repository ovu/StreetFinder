using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.NGram;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;

namespace StreetFinder
{
    public class StreetAnalyzer: Analyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            var stdTokenizer = new StandardTokenizer(Version.LUCENE_30, reader);
            var edgeTokens = new EdgeNGramTokenFilter(stdTokenizer, Side.FRONT, 3, 20);

            return edgeTokens;
        }
    }
}
