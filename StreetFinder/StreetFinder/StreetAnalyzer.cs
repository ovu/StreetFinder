using System.Collections.Generic;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.NGram;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;

namespace StreetFinder
{
    public class StreetAnalyzer: StandardAnalyzer
    {
        public StreetAnalyzer(Version matchVersion) : base(matchVersion)
        {
        }

        public StreetAnalyzer(Version matchVersion, ISet<string> stopWords) : base(matchVersion, stopWords)
        {
        }

        public StreetAnalyzer(Version matchVersion, FileInfo stopwords) : base(matchVersion, stopwords)
        {
        }

        public StreetAnalyzer(Version matchVersion, TextReader stopwords) : base(matchVersion, stopwords)
        {
        }

        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            var baseTokens = base.TokenStream(fieldName, reader);
            
            var edgeTokens = new EdgeNGramTokenFilter(baseTokens, Side.FRONT, 3, 20);

            return edgeTokens;
        }
    }
}
