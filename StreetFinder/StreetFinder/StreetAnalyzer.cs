using System.Collections.Generic;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.NGram;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;
using StreetFinder.SynonymFilter;

namespace StreetFinder
{
    public class StreetAnalyzer: Analyzer
    {
        public const int DEFAULT_MAX_TOKEN_LENGTH = 255;

        private const int maxTokenLength = DEFAULT_MAX_TOKEN_LENGTH;

        private readonly Version _matchVersion;

        public StreetAnalyzer(Version matchVersion)
        {
            this._matchVersion = matchVersion;
        }

        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            var tokenStream = new StandardTokenizer(_matchVersion, reader) {MaxTokenLength = maxTokenLength};

            TokenStream result = new StandardFilter(tokenStream);
            result = new LowerCaseFilter(result);
            
            var edgeTokens = new EdgeNGramTokenFilter(result, Side.FRONT, 1, 30);

            var synonymTokens = new SynonymTokenFilter(edgeTokens, new SynonymEngine());

            return synonymTokens;
        }
    }
}
