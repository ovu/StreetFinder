using System.Collections.Generic;

using Lucene.Net.Analysis;

using Lucene.Net.Analysis.Tokenattributes;

namespace StreetFinder.CombineFilter
{
    public class CombineTokenFilter : TokenFilter
    {
        private string lastTerm;

        private readonly Queue<string> _combinedTokensQueue = new Queue<string>();

        private bool addinCombinedTokens = false;

        public CombineTokenFilter(TokenStream input) : base(input)
        {
            lastTerm = "";
        }

        public override bool IncrementToken()
        {
            if (_combinedTokensQueue.Count > 0)
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();

                newAttribute.SetTermBuffer(_combinedTokensQueue.Dequeue());

                addinCombinedTokens = true;
                lastTerm = "";

                return true;
            }

            while (input.IncrementToken() && !addinCombinedTokens)
            {
                var attribute = input.GetAttribute<ITermAttribute>();

                if (attribute.Term.Equals("dr") || attribute.Term.Equals("prof") || attribute.Term.Equals("st"))
                {
                    _combinedTokensQueue.Enqueue(attribute.Term);

                    lastTerm = "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(lastTerm))
                    {
                        _combinedTokensQueue.Enqueue(lastTerm + attribute.Term);
                    }

                    lastTerm = attribute.Term;
                }
            }

            if (!string.IsNullOrEmpty(lastTerm))
            {
                _combinedTokensQueue.Enqueue(lastTerm);
            }

            if (_combinedTokensQueue.Count > 0)
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();

                newAttribute.SetTermBuffer(_combinedTokensQueue.Dequeue());

                addinCombinedTokens = true;
                lastTerm = "";

                return true;
            }

            return false;
        }
    }
}