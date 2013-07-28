using System;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace StreetFinder.AbbreviationsFilter
{
    public class AbbreviationTokenFilter: TokenFilter
    {
        public IAbbreviationsEngine AbbreviationsEngine { get; private set; }

        private bool _abbreviationsWereAdded = false;

        private AbbreviationTokenExpander _abbreviationsTokenExpander = new AbbreviationTokenExpander();

        public AbbreviationTokenFilter(TokenStream input, IAbbreviationsEngine abbreviationsEngine)
            : base(input)
        {
            if (abbreviationsEngine == null)
                throw new ArgumentNullException("abbreviationsEngine");

            AbbreviationsEngine = abbreviationsEngine;
        }

        public override bool IncrementToken()
        {
            if (_abbreviationsWereAdded && _abbreviationsTokenExpander.NextElement())
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();
                newAttribute.SetTermBuffer(_abbreviationsTokenExpander.CurrentElement());
                return true;
            }

            while (input.IncrementToken() && !_abbreviationsWereAdded)
            {
                var attribute = input.GetAttribute<ITermAttribute>();
                _abbreviationsTokenExpander.Add(attribute.Term);
            }

            if (_abbreviationsTokenExpander.NextElement())
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();

                newAttribute.SetTermBuffer(_abbreviationsTokenExpander.CurrentElement());

                _abbreviationsWereAdded = true;

                return true;
            }

            return false;
        }
    }
}