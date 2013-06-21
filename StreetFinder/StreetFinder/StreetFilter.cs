using System;
using Lucene.Net.Index;
using Lucene.Net.Search;

namespace StreetFinder
{
    public class StreetFilter: Filter
    {
        public override DocIdSet GetDocIdSet(IndexReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
