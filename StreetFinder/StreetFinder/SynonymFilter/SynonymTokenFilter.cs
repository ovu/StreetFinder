using System;
using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace StreetFinder.SynonymFilter
{
    public class SynonymTokenFilter: TokenFilter
    {
        private readonly Queue<string> _synonymTokenQueue = new Queue<string>();

        public ISynonymEngine SynonymEngine { get; private set; }

        public SynonymTokenFilter(TokenStream input, ISynonymEngine synonymEngine)
            : base(input)
        {
            if (synonymEngine == null)
                throw new ArgumentNullException("synonymEngine");

            SynonymEngine = synonymEngine;
        }

        public override bool IncrementToken()
        {
            var attribute = input.GetAttribute<ITermAttribute>();
            if (_synonymTokenQueue.Count > 0)
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();
                newAttribute.SetTermBuffer(_synonymTokenQueue.Dequeue());
                return true;
            }

            if (attribute.Term.EndsWith("str"))
            {
                var newAttribute = input.AddAttribute<ITermAttribute>();
                newAttribute.SetTermBuffer("strasse");

                //Add other synonyms
                _synonymTokenQueue.Enqueue("straße");

                return true;
            }

            return input.IncrementToken();
        }
    }
}