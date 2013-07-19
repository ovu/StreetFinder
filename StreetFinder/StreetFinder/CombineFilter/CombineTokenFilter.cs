using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace StreetFinder.CombineFilter
{
    public class CombineTokenFilter : TokenFilter
    {
        private readonly Queue<string> _combinedTokenQueue = new Queue<string>();

        public CombineTokenFilter(TokenStream input) : base(input)
        {
        }

        public override bool IncrementToken()
        {
            var attribute = input.GetAttribute<ITermAttribute>();
            if (string.IsNullOrEmpty(attribute.Term))
            {
                return input.IncrementToken();
            }

            if (_combinedTokenQueue.Count > 0)
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();
                var combinedValue = _combinedTokenQueue.Dequeue() + attribute.Term;
                newAttribute.SetTermBuffer(combinedValue);
                return true;
            }

            if (!attribute.Term.Equals("dr") && !attribute.Term.Equals("prof") && !attribute.Term.Equals("st"))
            {                
                //Add last word
                _combinedTokenQueue.Enqueue(attribute.Term);

                return input.IncrementToken();
            }

            return input.IncrementToken();
        }
    }
}