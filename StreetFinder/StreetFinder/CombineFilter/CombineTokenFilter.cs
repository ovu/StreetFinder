using Lucene.Net.Analysis;

using Lucene.Net.Analysis.Tokenattributes;

namespace StreetFinder.CombineFilter
{
    public class CombineTokenFilter : TokenFilter
    {
        private bool addinCombinedTokens = false;

        private StreetTokenCombiner _streetTokenCombiner = new StreetTokenCombiner();

        public CombineTokenFilter(TokenStream input) : base(input)
        {
        }

        public override bool IncrementToken()
        {
            if (addinCombinedTokens && _streetTokenCombiner.NextElement())
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();

                newAttribute.SetTermBuffer(_streetTokenCombiner.CurrentElement());

                return true;
            }

            while (input.IncrementToken() && !addinCombinedTokens)
            {
                var attribute = input.GetAttribute<ITermAttribute>();
                _streetTokenCombiner.Add(attribute.Term);
            }

            if (_streetTokenCombiner.NextElement())
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();

                newAttribute.SetTermBuffer(_streetTokenCombiner.CurrentElement());

                addinCombinedTokens = true;

                return true;
            }

            return false;
        }
    }
}