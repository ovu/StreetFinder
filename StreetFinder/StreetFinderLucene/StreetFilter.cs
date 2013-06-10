using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Index;
using Lucene.Net.Search;

namespace StreetFinderLucene
{
    public class StreetFilter: Filter
    {
        public override DocIdSet GetDocIdSet(IndexReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
