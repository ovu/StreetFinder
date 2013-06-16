using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using StreetFinderInterface;
using Directory = System.IO.Directory;
using Version = Lucene.Net.Util.Version;

namespace StreetFinderLucene
{
    public class StreetRepositoryLucene: IStreetSearchRepository
    {
        private string _streetsIndex = "LuceneIndex";
        private string _luceneEdgeGramIndexDir = "LuceneEdgegramIndex";

        private string StreetsIndexDirectory {
            get
            {
                return Environment.CurrentDirectory + "\\" + _streetsIndex;
            }
        }

        private string StreetsEdgeGramIndexDirectory
        {
            get
            {
                return Environment.CurrentDirectory + "\\" + _luceneEdgeGramIndexDir;
            }
        }

        public void CreateStreetRepository()
        {
            FSDirectory.Open(new DirectoryInfo(StreetsIndexDirectory));
            FSDirectory.Open(new DirectoryInfo(StreetsEdgeGramIndexDirectory));

        }

        public bool ExistStreetRepository()
        {
            return Directory.Exists(StreetsIndexDirectory);
        }

        public void DeleteStreetRepository()
        {
            Directory.Delete(StreetsIndexDirectory, true);
        }

        public IEnumerable<Street> SearchForStreets(int zipCode, string streetName)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(StreetsIndexDirectory));

            foreach (var street in SearchStreetInIndex(zipCode, streetName, directory)) yield return street;

            var ngramDirectory = FSDirectory.Open(new DirectoryInfo(StreetsEdgeGramIndexDirectory));

            foreach (var street in SearchStreetInIndex(zipCode, streetName, ngramDirectory)) yield return street;

        }

        private string GetQueryForStreetName(string streetName, string queryOperator)
        {
            var streetNameTrimmed = streetName.Trim('-', ' ');
            var streetNameWithoutMinus = streetNameTrimmed.Replace('-', ' ');
            var streetNameWithOneSpace = Regex.Replace(streetNameWithoutMinus, @"\s+", " ");

            var streetNameTokens = streetNameWithOneSpace.Replace('-', ' ').Split(' ');

            var result = "";
            foreach (var streetNameToken in streetNameTokens)
            {
                result += string.Format("+Name:{0}{1} ", streetNameToken, queryOperator);
            }

            return result;
        }

        private IEnumerable<Street> SearchStreetInIndex(int zipCode, string streetName, FSDirectory directory)
        {
            IndexReader indexReader = IndexReader.Open(directory, true);

            Searcher indexSearch = new IndexSearcher(indexReader);

            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);

            var queryParser = new QueryParser(Version.LUCENE_30, "Name", analyzer);

            var booleanQuery = new BooleanQuery();
            booleanQuery.Add(new TermQuery(new Term("Pobox", zipCode.ToString(CultureInfo.InvariantCulture))), Occur.MUST);

            booleanQuery.Add(new PrefixQuery(new Term("Name", streetName)), Occur.MUST);

            TopDocs resultDocs = indexSearch.Search(booleanQuery, 5);

            var hits = resultDocs.ScoreDocs;

            var foundIds = new List<string>();

            foreach (var hit in hits)
            {
                var documentFromSearcher = indexSearch.Doc(hit.Doc);
                foundIds.Add(documentFromSearcher.Get("Id"));

                yield return
                    new Street {Name = documentFromSearcher.Get("Name"), Pobox = int.Parse(documentFromSearcher.Get("Pobox"))};
            }

            // Search with Query parser
            var streetNameQuery = GetQueryForStreetName(streetName, "*");
            var query = queryParser.Parse(string.Format("{0} AND Pobox:{1}", streetNameQuery, zipCode));

            resultDocs = indexSearch.Search(query, 5);
            hits = resultDocs.ScoreDocs;

            foreach (var hit in hits)
            {
                var documentFromSearcher = indexSearch.Doc(hit.Doc);
                if (!foundIds.Contains(documentFromSearcher.Get("Id")))
                {
                    yield return
                        new Street
                            {
                                Name = documentFromSearcher.Get("Name"),
                                Pobox = int.Parse(documentFromSearcher.Get("Pobox"))
                            };
                }
            }

            indexSearch.Dispose();

            directory.Dispose();
        }

        public void InsertStreet(Street street)
        {
            var streetDocument = new Document();
            streetDocument.Add(new Field("Id", Guid.NewGuid().ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            streetDocument.Add(new Field("Name", street.Name, Field.Store.YES, Field.Index.ANALYZED));
            streetDocument.Add(new Field("Pobox", street.Pobox.ToString(CultureInfo.InvariantCulture), Field.Store.YES, Field.Index.NOT_ANALYZED));

            var directory = FSDirectory.Open(new DirectoryInfo(StreetsIndexDirectory));
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
            
            var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);

            writer.AddDocument(streetDocument);

            writer.Optimize();

            writer.Commit();

            writer.Dispose(true);

            // Write edgegram
            var edgeDirectory = FSDirectory.Open(new DirectoryInfo(StreetsEdgeGramIndexDirectory));
            var streetEdgeGramAnalyzer = new StreetAnalyzer();

            var edgeGramWriter = new IndexWriter(edgeDirectory, streetEdgeGramAnalyzer, true, IndexWriter.MaxFieldLength.LIMITED);

            edgeGramWriter.AddDocument(streetDocument);

            edgeGramWriter.Optimize();

            edgeGramWriter.Commit();

            edgeGramWriter.Dispose(true);
        }

        public void InsertStreets(IList<Street> streets)
        {
            throw new NotImplementedException();
        }
    }
}
