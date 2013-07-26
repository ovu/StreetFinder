using System;
using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace StreetFinder.AbbreviationsFilter
{
    public class AbbreviationTokenFilter: TokenFilter
    {
        private readonly Queue<string> _abbreviationsTokenQueue = new Queue<string>();

        public IAbbreviationsEngine AbbreviationsEngine { get; private set; }

        private bool _abbreviationsWereAdded = false;

        public AbbreviationTokenFilter(TokenStream input, IAbbreviationsEngine abbreviationsEngine)
            : base(input)
        {
            if (abbreviationsEngine == null)
                throw new ArgumentNullException("abbreviationsEngine");

            AbbreviationsEngine = abbreviationsEngine;
        }

        public override bool IncrementToken()
        {
            var attribute = input.GetAttribute<ITermAttribute>();
            if (_abbreviationsTokenQueue.Count > 0)
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();
                newAttribute.SetTermBuffer(_abbreviationsTokenQueue.Dequeue());
                return true;
            }

            if (attribute.Term.EndsWith("str"))
            {
                List<string> abbreviations;
                if (AbbreviationsEngine.HasAbbreviationsOrIsAbbreviation("str", out abbreviations))
                {
                    _abbreviationsTokenQueue.Enqueue(attribute.Term);

                    foreach (var abbreviation in abbreviations)
                    {
                        _abbreviationsTokenQueue.Enqueue(abbreviation);
                    }
                }

                return true;
            }
            
            if (!_abbreviationsWereAdded && !attribute.Term.Equals(""))
            {
                List<string> abbreviations;
                if (AbbreviationsEngine.HasAbbreviationsOrIsAbbreviation(attribute.Term, out abbreviations))
                {
                    _abbreviationsTokenQueue.Enqueue(attribute.Term);

                    foreach (var abbreviation in abbreviations)
                    {
                        _abbreviationsTokenQueue.Enqueue(abbreviation);
                    }
                }
                _abbreviationsWereAdded = true;
            }

            return input.IncrementToken();
        }
    }
}