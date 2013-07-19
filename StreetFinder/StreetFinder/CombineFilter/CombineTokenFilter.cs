using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace StreetFinder.CombineFilter
{
    public class CombineTokenFilter : TokenFilter
    {
        private  string lastTerm;
        private readonly Queue<string> _combinedTokensQueue = new Queue<string>();
        private bool addinCombinedTokens = false;

        public CombineTokenFilter(TokenStream input) : base(input)
        {
            lastTerm = "";
        }

        public override bool IncrementToken()
        {
            var attribute = input.GetAttribute<ITermAttribute>();

            if (string.IsNullOrEmpty(attribute.Term))
            {
                return input.IncrementToken();
            }

            var currentTerm = attribute.Term;

            if (!addinCombinedTokens)
            {
                if (!string.IsNullOrEmpty(lastTerm))
                {
                    _combinedTokensQueue.Enqueue(lastTerm + currentTerm);
                }

                if (!attribute.Term.Equals("dr") && !attribute.Term.Equals("prof") && !attribute.Term.Equals("st"))
                {
                    //Add last word
                    lastTerm = attribute.Term;
                }
                else
                {
                    lastTerm = "";
                }
                var resultIncrement = input.IncrementToken();
                if (!resultIncrement && _combinedTokensQueue.Count > 0)
                {
                    addinCombinedTokens = true;
                    lastTerm = "";
                    if (_combinedTokensQueue.Count > 0)
                    {
                        var newAttribute = input.AddAttribute<ITermAttribute>();
                        newAttribute.SetTermBuffer(_combinedTokensQueue.Dequeue());
                        lastTerm = "";
                        return true;
                    }
                }
                return resultIncrement;

            }

            if (_combinedTokensQueue.Count > 0)
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();
                newAttribute.SetTermBuffer(_combinedTokensQueue.Dequeue());
                lastTerm = "";
                return true;
            }

            return false;
        }
    }
}