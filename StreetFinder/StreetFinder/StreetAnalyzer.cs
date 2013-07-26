using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.NGram;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;
using StreetFinder.AbbreviationsFilter;
using StreetFinder.CombineFilter;

namespace StreetFinder
{
    public class StreetAnalyzer: Analyzer
    {
        public const int DEFAULT_MAX_TOKEN_LENGTH = 255;

        private const int maxTokenLength = DEFAULT_MAX_TOKEN_LENGTH;

        private readonly Version _matchVersion;

        public StreetAnalyzer(Version matchVersion)
        {
            _matchVersion = matchVersion;
        }

        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            var tokenStream = new StandardTokenizer(_matchVersion, reader) {MaxTokenLength = maxTokenLength};

            TokenStream result = new StandardFilter(tokenStream);
            result = new LowerCaseFilter(result);

            var combineResult = new CombineTokenFilter(result);

            var synonymTokens = new AbbreviationTokenFilter(combineResult, new AbbreviationsEngine());

            var edgeTokens = new EdgeNGramTokenFilter(synonymTokens, Side.FRONT, 3, 30);

            return edgeTokens;
        }
    }
}
